using System.ComponentModel.DataAnnotations;

namespace L5A2Programming.Models
{
    public class InstitutionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string Address { get; set; }
    }
}
