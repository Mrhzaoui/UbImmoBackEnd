using System.ComponentModel.DataAnnotations;

namespace UBEE.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } // e.g., "PropertyOwner", "Buyer", "Notary", "Broker"

        public List<Property> Properties { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}

