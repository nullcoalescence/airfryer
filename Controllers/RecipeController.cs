using airfryer.Db;
using airfryer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace airfryer.Controllers;

public class RecipeController : Controller
{
    private readonly ILogger<RecipeController> _logger;
    private readonly AirfryerContext _dbContext;

    public RecipeController(ILogger<RecipeController> logger, AirfryerContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        
        var recipes = _dbContext.Recipes.AsQueryable();
        var recipeViewModels = new List<RecipeViewModel>();
        foreach (var recipe in recipes)
        {
            recipeViewModels.Add(RecipeMapper.ToViewModel(recipe));
        }
        
        return View(recipeViewModels);
    }
}