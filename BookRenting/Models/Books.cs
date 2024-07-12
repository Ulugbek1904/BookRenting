namespace BookRenting.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; } 
        public string Author { get; set; }

        public DateOnly PublishedAt { get; set; }
        public int Version { get; set; } 
    }
}
