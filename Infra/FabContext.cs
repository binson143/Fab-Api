using System.Collections.Generic;
using Fab.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fab.Api.Infra
{
    public class FabContext:DbContext
    {
        public FabContext(DbContextOptions<FabContext> options):base(options)
        {
            
        }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Installment> Installments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasMany(y => y.Installments)
                .WithOne(x => x.Loan);
            
           
        }
    }
}