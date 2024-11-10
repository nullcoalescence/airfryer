using Riok.Mapperly.Abstractions;

namespace airfryer.Models;

public class RecipeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

[Mapper]
public static partial class RecipeMapper
{
    public static partial RecipeViewModel ToViewModel(Recipe entity);
    public static partial Recipe ToEntity(RecipeViewModel viewModel);
}