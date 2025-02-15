using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CatsMVC.Data.Entities;

namespace CatsMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Visit>()
                .HasKey(v => new { v.CatId, v.VetId });

            builder.Entity<Visit>()
                .HasOne(v => v.Cat)
                .WithMany(c => c.Visits)
                .HasForeignKey(v => v.CatId);

            builder.Entity<Visit>()
                .HasOne(v => v.Vet)
                .WithMany(vet => vet.Visits)
                .HasForeignKey(v => v.VetId);

        }
        public DbSet<CatsMVC.Data.Entities.Cat> Cat { get; set; } = default!;
    }
}
