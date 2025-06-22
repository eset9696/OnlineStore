namespace OnlineStore.Models.Entities
{
    public class Review
    {
        public long Id { get; set; }

        public required long ProductId { get; set; }
        public required string Author { get; set; }
        public string? Content { get; set; }

        public required short Raiting { get; set; }


    }
}
