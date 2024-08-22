using Shopping.Domain.Common;
using Shopping.Domain.Users;

namespace Shopping.Domain.Carts;

public class Cart : Entity
{
    public string BuyerId { get; set; }
    public CartStatus Status { get; set; }

    public User User { get; set; }
    public List<CartItem> Items { get; set; } = [];
}