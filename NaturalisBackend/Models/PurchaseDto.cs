namespace NaturalisBackend.Models
{
    public class PurchaseDto
    {
        public UserDto User { get; set; }
        public DeliveryDto Delivery { get; set; }
        public PaymentDto Payment { get; set; }
        public List<CartItemDto> Cart { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }

    public class DeliveryDto
    {
        public string Address { get; set; }
        public string Zip { get; set; }
    }

    public class PaymentDto
    {
        public string Method { get; set; }
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Cvv { get; set; }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductType { get; set; }
        public int Quantity { get; set; }
    }

}
