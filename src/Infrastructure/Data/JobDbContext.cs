using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class JobDbContext
    (DbContextOptions<JobDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
}