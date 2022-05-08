using System.ComponentModel.DataAnnotations;

namespace L5A2Programming.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
