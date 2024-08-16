using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<tblM_Gender> tblM_Gender { get; set; }
        public DbSet<tblM_Hobi> tblM_Hobi { get; set; }
        public DbSet<tblT_Personal> tblT_Personal { get; set; }
        public DbSet<tblT_Umur> tblT_Umur { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblT_Personal>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.IdGender);

            modelBuilder.Entity<tblT_Personal>()
                .HasOne(p => p.Hobi)
                .WithMany()
                .HasForeignKey(p => p.IdHobi);

            base.OnModelCreating(modelBuilder);
        }
    }
}