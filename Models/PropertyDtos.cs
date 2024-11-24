using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class PropertyCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }

    public class PropertyUpdateDto
    {
        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}

