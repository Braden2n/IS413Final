using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Entertainer> Entertainers { get; set; }
}