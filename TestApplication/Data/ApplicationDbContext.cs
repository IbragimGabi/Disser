using TestApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }
        public virtual DbSet<TestTask> TestTasks { get; set; }
        public virtual DbSet<Test> Tests { get; set; }


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

            builder.Entity<TestTask>(entity =>
            {
                entity.HasIndex(e => e.TestTaskId);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestTasks)
                    .HasForeignKey(t => new { t.TestId });
            });

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
