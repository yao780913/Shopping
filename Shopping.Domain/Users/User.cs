using Shopping.Domain.Common;
using Shopping.Domain.Common.Interfaces;

namespace Shopping.Domain.Users;

public class User : Entity
{
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
    public string Email { get; } = null!;

    private readonly string _passwordHash = null!;

    public User(
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _passwordHash = passwordHash;
    }

    public bool IsCorrectPasswordHash(string password, IPasswordEncryptor passwordEncryptor)
    {
        return password == passwordEncryptor.Decrypt(_passwordHash);
    }
}