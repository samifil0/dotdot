using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.DAL.EF;

public class PlayerAgentDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public PlayerAgentDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = "Data Source=playeragent.db";
        optionsBuilder
            .UseSqlite(dbPath)
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Player>()
            .HasOne(p => p.Agent)
            .WithMany(a => a.Players);
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Player)
            .WithMany(p => p.Contracts);
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Team)
            .WithMany(t => t.Contracts);
        
    }


    public bool CreateDatabase(bool removeDatabase)
    {
        if (removeDatabase)
        {
            Database.EnsureDeleted();
        }

        return Database.EnsureCreated();
    }

}