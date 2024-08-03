 namespace Admin.Models
{
    public class UpdateProductDto
    {
        public required string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
