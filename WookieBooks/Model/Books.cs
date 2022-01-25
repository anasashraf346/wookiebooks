namespace WebApplication1.Models
{
    public class Books
    {

        public int BookId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }

        public string Author { get; set; }

        public string CoverImage { get; set; }
        public int Price { get; set; }

    }
}
