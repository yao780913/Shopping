using Shopping.Domain.Common;

namespace Shopping.Domain.Books;

public class Author : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
}