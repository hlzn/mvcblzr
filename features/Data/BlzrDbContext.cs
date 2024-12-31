using features.Models;
using Microsoft.EntityFrameworkCore;

namespace features.Data;

public class BlzrDbContext : DbContext
{
    public BlzrDbContext(DbContextOptions<BlzrDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
}