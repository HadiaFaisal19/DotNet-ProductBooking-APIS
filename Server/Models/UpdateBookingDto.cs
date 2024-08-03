namespace Admin.Models
{
    public class UpdateBookingDto
    {
        public required string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceContact { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartShift { get; set; }
        public string EndShift { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalBill { get; set; }
        public List<int> ProductIds { get; set; } // List of Product IDs
    }
}
