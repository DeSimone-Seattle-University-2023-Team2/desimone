using System.Reflection;
using Application.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class JobDbContext : IdentityDbContext<ApplicationUser>, IJobDbContext
{
    public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

    public DbSet<Job> Jobs => Set<Job>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
