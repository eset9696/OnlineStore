namespace OnlineStore.Models.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }

    }
}
