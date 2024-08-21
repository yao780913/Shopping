namespace Shopping.Contracts.Carts;

public class CreateCartRequest
{
    public string BookId { get; set; }
    public int Quantity { get; set; }
}