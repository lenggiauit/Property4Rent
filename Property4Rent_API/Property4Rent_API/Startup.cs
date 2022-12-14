using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Property4Rent.API.Domain.Entities;
using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Domain.Repositories;
using Property4Rent.API.Domain.Services;
using Property4Rent.API.Extensions;
using Property4Rent.API.Persistence.Repositories;
using Property4Rent.API.Services;
using System; 
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;

namespace Property4Rent_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DelayFilter));
            })
            .AddNewtonsoftJson();
            // Use microsoft DistributedMemoryCache
            services.AddDistributedMemoryCache();
            // if you want to use Redis cache
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "[yourconnection string]";
            //    option.InstanceName = "[your instance name]";
            //});

            // AppSetting
            var appSettingsSection = Configuration.GetSection("AppSettings");

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);

            services.AddCustomSwagger();
            services.AddControllers();
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                // Adds a custom error response factory when ModelState is invalid
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
                options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = appSettings.ClientErrorMappingUrl;
            });
            services.AddCors();
            services.AddDbContext<P4RContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Property4Rent"));
                option.EnableSensitiveDataLogging();
            });
            services.AddAutoMapper(typeof(Startup));
            // SignalR
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(appSettings.AllowOriginUrl, appSettings.AllowOriginUrl1, appSettings.AllowOriginUrl2, appSettings.AllowOriginUrl3, appSettings.AllowOriginUrl4)
                    .AllowCredentials();
            }));
            services.AddScoped<ConversationServiceHub>();
            services.AddSignalR();
            // services
            services.AddScoped<IAccountService, AccountService>(); 
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IRefService, RefService>(); 

            // Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();  
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IRefRepository, RefRepository>(); 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // File Service
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFileWriter, FileWriter>();

            services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddHttpClient();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var accService = context.HttpContext.RequestServices.GetRequiredService<IAccountService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = accService.GetById(userId).Result;
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/conversationServiceHub")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomSwagger(appSettings);

            app.UseStaticFiles();
            string fileFolder = Path.Combine(Directory.GetCurrentDirectory(), appSettings.FileFolderPath);
            if (!Directory.Exists(fileFolder))
                Directory.CreateDirectory(fileFolder);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), appSettings.FileFolderPath)),
                RequestPath = appSettings.FileRequestUrl
            });
              
            app.UseRouting();

            app.UseCors(x => x
                .WithOrigins(appSettings.AllowOriginUrl, appSettings.AllowOriginUrl1, appSettings.AllowOriginUrl2, appSettings.AllowOriginUrl3, appSettings.AllowOriginUrl4)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ConversationServiceHub>("/conversationServiceHub");
            });
        }
    }
}
