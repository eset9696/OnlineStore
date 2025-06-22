using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Domain
{
    public class Review
    {

        public long Id { get; set; }
        public required long ProductId { get; set; }

        
        public required string Author { get; set; }

        public string? Content { get; set; }
       
        public required int Rating { get; set; }

        public required DateTime CreatedAt { get; set; }

    }
}
