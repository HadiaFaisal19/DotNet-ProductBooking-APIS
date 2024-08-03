namespace Admin.Models.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public required string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceContact { get; set; }
        public List<Product> Products { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartShift { get; set; }
        public string EndShift { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalBill { get; set; }

    }
}
