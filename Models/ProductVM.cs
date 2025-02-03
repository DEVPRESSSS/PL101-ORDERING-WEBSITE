namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models
{
    public class ProductVM
    {

        public Products? Product { get; set; }  // Changed from 'products' to 'Product' for naming convention
        public Category? Category { get; set; }
        public List<string>? ImageUrls { get; set; }

    }
}
