namespace Shopping.Contracts.Carts;

public class CartItem
{
    public string CartItemId { get; set; }
    public string BookId { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
}