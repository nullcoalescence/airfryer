using System.ComponentModel.DataAnnotations;

namespace airfryer.Models.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [MaxLength(255)]
        public string Description { get; set; }
    }
}