using airfryer.Models;
using Microsoft.EntityFrameworkCore;

namespace airfryer.Db;

public class AirfryerContext(DbContextOptions<AirfryerContext> options) : DbContext(options)
{
    // Tables
    public DbSet<Recipe> Recipes { get; set; }
    
}