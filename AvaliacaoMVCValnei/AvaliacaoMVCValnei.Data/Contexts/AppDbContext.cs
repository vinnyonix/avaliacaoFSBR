using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AvaliacaoMVCValnei.Data.Entities;
using AvaliacaoMVCValnei.Data.Config;
using AvaliacaoMVCValnei.Data.Seeds;

namespace AvaliacaoMVCValnei.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration? _configuration;
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<ProcessEntity> Process { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProvaValneiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProcessSeed.Seed(modelBuilder);

            DefaultConfiguration.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}