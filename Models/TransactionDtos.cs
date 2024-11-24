using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class TransactionCreateDto
    {
        [Required]
        public int PropertyId { get; set; }

        [Required]
        public int BuyerId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; }
    }

    public class TransactionUpdateDto
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; }
    }
}

