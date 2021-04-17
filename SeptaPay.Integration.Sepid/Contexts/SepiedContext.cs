using Microsoft.EntityFrameworkCore;
using SeptaPay.Integration.Sepid.Model;
using System.Diagnostics.CodeAnalysis;

namespace SeptaPay.Integration.Sepid.Contexts
{
    public class SepidContext : DbContext
    {
        public SepidContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<PurchaseRequestEntity> PurchaseRequestEntities { get; set; }

        public DbSet<PurchaseResponseEntity> PurchaseResponseEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PurchaseRequestEntity>(x =>
            {
                x.ToTable("PurchaseRequest");

                x.HasKey(d => d.Id);

                x.HasOne(d => d.PurchaseResponse).WithOne(x => x.PurchaseRequestEntity)
                    .HasForeignKey<PurchaseRequestEntity>(x => x.PurchaseResponseId);
            });

            modelBuilder.Entity<PurchaseResponseEntity>(x =>
            {
                x.ToTable("PurchaseResponse");
                x.HasKey(d => d.Id);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}