namespace NaturalisBackend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string Image { get; set; }
        public int ProductType { get; set; }
        public ProductType ProductTypeNavigation { get; set; }

    }
}
