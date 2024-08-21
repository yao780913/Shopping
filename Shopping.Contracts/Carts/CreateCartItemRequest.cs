namespace Shopping.Contracts.Carts;

public class CreateCartItemRequest
{
    public string BookId { get; set; }
    public int Quantity { get; set; }
}