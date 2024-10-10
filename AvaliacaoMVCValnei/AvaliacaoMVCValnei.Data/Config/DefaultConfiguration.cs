using AvaliacaoMVCValnei.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoMVCValnei.Data.Config
{
    public static class DefaultConfiguration
    {
        public static ModelBuilder Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessEntity>(entity =>
            {
                entity.HasIndex(e => e.ProcessId).IsUnique();
                entity.Property(p => p.NPU).HasMaxLength(20).IsRequired();
                entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Municipality).HasMaxLength(50).IsRequired();
                entity.Property(p => p.FederativeUnit).HasMaxLength(2).IsRequired();
            });

            return modelBuilder;
        }
    }
}