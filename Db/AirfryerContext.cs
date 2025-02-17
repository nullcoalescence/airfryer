using airfryer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace airfryer.Db
{
    public class AirfryerContext : DbContext
    {
        public AirfryerContext(DbContextOptions<AirfryerContext> options) : base(options)
        {
            
        }
        
        public DbSet<Recipe> Recipes { get; set; }
    }
}