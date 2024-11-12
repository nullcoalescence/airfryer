using airfryer.Models;
using Microsoft.EntityFrameworkCore;

namespace airfryer.Db;

public class AirfryerContext : DbContext
{
    // Tables
    public DbSet<Recipe?> Recipes { get; set; }

    public AirfryerContext(DbContextOptions<AirfryerContext> options) : base(options)
    {
        
    }
    
}