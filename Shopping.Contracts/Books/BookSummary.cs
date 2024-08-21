namespace Shopping.Contracts.Books;

public class BookSummary
{
    public string BookId { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public List<BookAuthor> Authors { get; set; }
}