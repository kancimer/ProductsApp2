namespace ProductsApp2.Models.Domains
{
    public class Products
    {
        public Guid Id { get; set; }
        public string? ProductImageUrl { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
    }
}
