namespace FortalStore.Domain.StoreContext;

public class OrderItem
{
    public Product Product { get; private set; }
    public string Quantity { get; private set; }
    public string Price { get; private set; }
}