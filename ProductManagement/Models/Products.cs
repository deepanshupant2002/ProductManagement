using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 

        public string Description { get; set; }

        public string Image { get; set; }  

        public int Price { get; set; }
    }
}
