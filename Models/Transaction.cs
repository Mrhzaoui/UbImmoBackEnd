using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }

        public int BuyerId { get; set; }

        public int SellerId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Status { get; set; }

        public Property Property { get; set; }
        public User Buyer { get; set; }
        public User Seller { get; set; }
    }
}

