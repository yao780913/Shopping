namespace Shopping.Contracts.Books;

public class BookDetail
{
    public string BookId { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<BookAuthor> Authors { get; set; }
}