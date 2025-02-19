using airfryer.Db;
using airfryer.Models.Dto;

namespace airfryer.Services
{
    public class RecipeService
    {
        private readonly ILogger<RecipeService> _logger;
        private readonly AirfryerContext _dbContext;

        public RecipeService(ILogger<RecipeService> logger, AirfryerContext airfryerContext)
        {
            _logger = logger;
            _dbContext = airfryerContext;
        }

        // TODO this sucks, setup a source generator-based mapper
        public RecipeDto? GetRecipeById(int id)
        {
            var entity = _dbContext.Recipes.Find(id);
            if (entity != null)
            {
                return new RecipeDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };
            }

            return null;
        }
    }
}