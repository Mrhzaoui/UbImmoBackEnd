using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace UBEE.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public User User { get; set; }
        public List<Transaction> Transactions { get; set; }
        public AIEvaluation AIEvaluation { get; set; }
    }
}

