using Core.Security.Entities;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Devs.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Developer> Developers { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LanguageDbConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(a =>
        {
            a.ToTable("Languages").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");
            a.HasMany(p=>p.Technologies);
        });

        modelBuilder.Entity<Technology>(a =>
        {
            a.ToTable("Technologies").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.LanguageId).HasColumnName("LanguageId");
            a.Property(p => p.Name).HasColumnName("Name");
            a.HasOne(p => p.Language);
        });

        modelBuilder.Entity<User>(a =>
        {
            a.ToTable("Users").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.FirstName).HasColumnName("FirstName");
            a.Property(p => p.LastName).HasColumnName("LastName");
            a.Property(p => p.Email).HasColumnName("Email");
            a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            a.Property(p => p.Status).HasColumnName("Status");
            a.HasMany(p => p.UserOperationClaims);
            a.HasMany(p => p.RefreshTokens);
        });

        modelBuilder.Entity<OperationClaim>(a =>
        {
            a.ToTable("OperationClaims").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<UserOperationClaim>(a =>
        {
            a.ToTable("UserOperationClaims").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            a.HasOne(p=>p.User);
            a.HasOne(p=>p.OperationClaim);
        });

        modelBuilder.Entity<Developer>(a =>
        {
            a.ToTable("Developers").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.GithubAddress).HasColumnName("GithubAddress");
            a.HasOne(p=>p.User);
        });

        Language[] languageSeeds =
        {
            new(1, "C#"),
            new(2, "Java")
        };

        Technology[] technologySeeds =
        {
            new(1, 1, "ASP.NET"),
            new(2, 1, "WPF"),
            new(3, 2, "Spring"),
        };

        OperationClaim[] operationClaimSeeds =
        {
            new(1, "admin"),
            new(2, "developer")
        };



        modelBuilder.Entity<Language>().HasData(languageSeeds);
        modelBuilder.Entity<Technology>().HasData(technologySeeds);
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeeds);
    }
}