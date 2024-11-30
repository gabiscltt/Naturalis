namespace NaturalisBackend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }

}
