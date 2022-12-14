using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Property4Rent.API.Domain.Entities
{
    public partial class P4RContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); }); 

        public P4RContext(DbContextOptions<P4RContext> dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<ConversationMessage> ConversationMessage { get; set; }
        public virtual DbSet<ConversationUsers> ConversationUsers { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionInRole> PermissionInRole { get; set; }
        public virtual DbSet<Priority> Priority { get; set; } 
        public virtual DbSet<Role> Role { get; set; } 
        public virtual DbSet<User> User { get; set; } 
        public virtual DbSet<Language> Language { get; set; } 
        //
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<City> City { get; set; } 
        
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlacePhoto> PlacePhoto { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<Utility> Utility { get; set; }
        public virtual DbSet<PropertyUtilities> PropertyUtilities { get; set; }
        public virtual DbSet<PropertyNearBy> PropertyNearBy { get; set; }
        public virtual DbSet<PropertyPhoto> PropertyPhoto { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CommentContent).HasColumnName("Comment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastMessage).HasMaxLength(500);

                entity.Property(e => e.LastMessageDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<ConversationMessage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LovedByUids)
                    .HasColumnName("LovedByUIds")
                    .HasMaxLength(1000);

                entity.Property(e => e.Message).HasMaxLength(1500);

                entity.Property(e => e.SeenByUids)
                    .HasColumnName("SeenByUIds")
                    .HasMaxLength(1000);

                entity.Property(e => e.SendDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConversationUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PermissionInRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

               
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

             
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsSystemRole).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
             
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
                 
                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserName).HasMaxLength(250);
 
            }); 

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

            });

            modelBuilder.Entity<Country>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true); 
            });

            modelBuilder.Entity<State>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true);
            });

            modelBuilder.Entity<City>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true);
            });
            modelBuilder.Entity<PlacePhoto>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true);
            });
             

            modelBuilder.Entity<PlacePhoto>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true);
            });

            modelBuilder.Entity<PropertyType>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsPublic).HasDefaultValue(true);
            });
            modelBuilder.Entity<PropertyUtilities>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever(); 
            });
            modelBuilder.Entity<Property>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();

            });
            modelBuilder.Entity<PropertyPhoto>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever(); 
            });
            modelBuilder.Entity<PropertyNearBy>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<Utility>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
