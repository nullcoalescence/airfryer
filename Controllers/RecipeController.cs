using airfryer.Db;
using airfryer.Models;
using airfryer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace airfryer.Controllers;

public class RecipeController : Controller
{
    private readonly ILogger<RecipeController> _logger;
    private readonly RecipeService _recipeService;
    public RecipeController(ILogger<RecipeController> logger, RecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    public IActionResult Index()
    {
        var entities = _recipeService.GetAll();
        var recipeViewModels = new List<RecipeViewModel>();
        foreach (var entity in entities)
        {
            recipeViewModels.Add(RecipeMapper.ToViewModel(entity));
        }
        
        return View(recipeViewModels);
    }

    public IActionResult Add()
    {
        return View();
    }

    public async Task<IActionResult> Recipe(int id)
    {
        var entity = await _recipeService.GetByIdAsnyc(id);
        var viewModel = RecipeMapper.ToViewModel(entity);
        
        return View(viewModel);
    }
}