namespace NaturalisBackend.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }

}
