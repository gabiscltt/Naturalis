using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalisBackend.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public User UserData { get; set; }
        public int UserId { get; set; }
        public Delivery DeliveryData { get; set; }
        public Payment PaymentData { get; set; }
        public List<CartItem> CartItems { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductType { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

}
