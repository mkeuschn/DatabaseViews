using DatabaseViews.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseViews.DataAccessLayer.Context
{
    public class CloudContext : DbContext
    {
        public CloudContext() { }

        public CloudContext(DbContextOptions<CloudContext> options) : base(options) { }

        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Host>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViwHost");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("text");

                entity.Property(e => e.UserPersonnelNumber)
                    .HasColumnName("RelatedUser")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViwUser");

                entity.Property(e => e.PersonnelNumber)
                    .HasColumnName("CompanyId")
                    .HasColumnType("text");

                entity.Property(e => e.LoginName)
                    .HasColumnName("LoginName")
                    .HasColumnType("text");
            });

            // base.OnModelCreating(modelBuilder);
        }
    }
}