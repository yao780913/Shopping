namespace Shopping.Contracts.Carts;

public class CartDetail
{
    public string CartId { get; set; }
    public List<CartItem> Items { get; set; }
    public int TotalCostInCents { get; set; }
    public CartStatus CartStatus { get; set; }
}