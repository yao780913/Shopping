using Shopping.Domain.Common;

namespace Shopping.Domain.Carts;

public class CartItem : Entity
{
    public string BookId { get; set; }
    public int Quantity { get; set; }
    
    public Guid CartId { get; set; }
    
    public Cart Cart { get; set; }
}