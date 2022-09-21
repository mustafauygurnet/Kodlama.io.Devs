using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Devs.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Language> Languages { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LanguageDbString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(x =>
        {
            x.ToTable("Languages").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");
        });

        Language[] languageSeeds =
        {
            new(1, "C#"),
            new(2, "Java")
        };

        modelBuilder.Entity<Language>().HasData(languageSeeds);
    }
}