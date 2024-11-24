using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class ServiceCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }

    public class ServiceUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}

