namespace UBEE.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
    }
}

