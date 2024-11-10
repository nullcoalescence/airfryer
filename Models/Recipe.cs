using System.ComponentModel.DataAnnotations;

namespace airfryer.Models;

public class Recipe
{
   [Key]
   public int Id { get; set; }
   
   [Required]
   [MaxLength(50)]
   public string Name { get; set; }
   
   [MaxLength(255)]
   public string? Description { get; set; }
}