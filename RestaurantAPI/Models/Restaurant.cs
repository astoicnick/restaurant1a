using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    // Restaurant Entity
    // Entity is just a business object we're storing in the database
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Hours { get; set; }
        public string Address { get; set; }
        [Required]
        public string Cuisine { get; set; }
    }
}