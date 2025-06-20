namespace OnlineStore.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
