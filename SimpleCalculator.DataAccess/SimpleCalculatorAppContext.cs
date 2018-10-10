using Microsoft.EntityFrameworkCore;
using SimpleCalculator.DomainEntities;

namespace SimpleCalculator.DataAccess
{
    public class SimpleCalculatorAppContext : DbContext
    {

        public SimpleCalculatorAppContext(DbContextOptions<SimpleCalculatorAppContext> options) : base(options)
        {
        }

        public virtual DbSet<Diagnostics> Diagonostics { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnostics>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(4000);               
            });
        }
    }
}