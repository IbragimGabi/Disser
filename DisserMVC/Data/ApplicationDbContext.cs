using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DisserMVC.Models;

namespace DisserMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }
        public virtual DbSet<TestTasks> TestTasks { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.CurrentState)
                    .HasColumnType("int");
            });

            builder.Entity<TestQuestion>(entity =>
            {
                entity.HasIndex(e => e.TestTaskId);

                entity.HasOne(d => d.TestTask)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.TestTaskId);
            });

            builder.Entity<TestTasks>(entity =>
            {
                entity.HasIndex(e => e.TestId);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestTasks)
                    .HasForeignKey(d => d.TestId);
            });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
