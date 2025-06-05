namespace OnlineStore.Models.Domain
{
    public class ReviewModel
    {

        public int Id { get; set; }
        public required string Author { get; set; }
        public string? Review { get; set; }
        public required int Rating { get; set; }
    }
}
