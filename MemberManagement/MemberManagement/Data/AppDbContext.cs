using MemberManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MemberManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
