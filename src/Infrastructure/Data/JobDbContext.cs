using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Application.Entities;
using Application.Interfaces;

namespace Infrastructure.Data;

public class JobDbContext : IdentityDbContext<ApplicationUser>, IJobDbContext
{
    public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<CpuType> CpuTypes => Set<CpuType>();
    public DbSet<JobSpeed> JobSpeeds => Set<JobSpeed>();
    public DbSet<JobStatus> JobStatuses => Set<JobStatus>();
    public DbSet<JobSubscription> JobSubscriptions => Set<JobSubscription>();
    public DbSet<JobType> JobTypes => Set<JobType>();
    public DbSet<MemoryType> MemoryTypes => Set<MemoryType>();
    public DbSet<Project> Projects => Set<Project>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetEntityTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    public override int SaveChanges()
    {
        SetEntityTimeStamps();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    
    private void SetEntityTimeStamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is Entity && (e.State == EntityState.Added || e.State == EntityState.Modified));
        
        foreach (var entry in entries)
        {
            var entity = (Entity)entry.Entity;
            var utcNow = DateTime.UtcNow;
            entity.UpdatedAt = utcNow;
            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = utcNow;
            }
        }
    }
}
