namespace RestWithASPNET10Erudio.Data.DTO
{
    public class BooksDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
