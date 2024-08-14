using CdbDomain.Domain;
using Microsoft.EntityFrameworkCore;

namespace CdbInfra.Context
{
    public  class CdbContext : DbContext
    {
    
        public CdbContext(DbContextOptions<CdbContext> options)
        : base(options)
        { }

        public DbSet<TaxaBancaria> TaxaBancarias { get; set; }
        public DbSet<TaxaMensal> TaxaMensal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("CnnStr");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<TaxaBancaria>().HasData(
                    new TaxaBancaria
                    {
                        Id = 1,
                        Tb = 1.08M ,
                        Cdb = 0.009M
                    }
                );
            modelBuilder.Entity<TaxaMensal>().HasData(
                new { Id = 1, Taxa = 0.225M, Meses = 6 },
                new { Id = 2, Taxa = 0.20M, Meses = 12 },
                new { Id = 3, Taxa = 0.175M, Meses = 24 },
                new { Id = 4, Taxa = 0.15M, Meses = 0 }
            );

        }

    }
}
