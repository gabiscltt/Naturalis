namespace NaturalisBackend.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Method { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Cvv { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }

}
