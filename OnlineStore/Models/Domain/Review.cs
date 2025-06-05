namespace OnlineStore.Models.Domain
{
    public class Review
    {

        public required int Id { get; set; }
        public required int ProductId { get; set; }
        public required string Author { get; set; }
        public string? ReviewText { get; set; }
        public required int Rating { get; set; }

        public string CreationTime { get; set; }
    }
}
