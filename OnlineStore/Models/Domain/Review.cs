namespace OnlineStore.Models.Domain
{
    public class Review
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string Author { get; set; }
        public string? ReviewText { get; set; }
        public required int Rating { get; set; }
    }
}
