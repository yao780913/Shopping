using Shopping.Domain.Common;

namespace Shopping.Domain.Books;

public class Book : Entity
{
    public string Name { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}