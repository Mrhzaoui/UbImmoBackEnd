using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } // e.g., "Legal", "Photography", "Inspection"
    }
}

