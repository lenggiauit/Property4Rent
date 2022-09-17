using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Property4Rent.API.Domain.Entities;
using System; 

namespace Property4Rent_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<P4RContext>())
            {
                try
                {
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            } 

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
