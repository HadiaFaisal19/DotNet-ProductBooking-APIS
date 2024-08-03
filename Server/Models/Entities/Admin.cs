namespace Admin.Models.Entities
{
    public class Admin
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public string email { get; set; }
    }
}
