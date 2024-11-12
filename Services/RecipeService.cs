using airfryer.Db;
using airfryer.Models;

namespace airfryer.Services;

public class RecipeService
{
    private readonly ILogger<RecipeService> _logger;
    private readonly AirfryerContext _dbContext;

    public RecipeService(ILogger<RecipeService> logger, AirfryerContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Recipe?> GetByIdAsnyc(int id)
    {
        return await _dbContext.Recipes.FindAsync(id);
    }

    public IQueryable<Recipe?> GetAll()
    {
        return _dbContext.Recipes.AsQueryable();
    }
}