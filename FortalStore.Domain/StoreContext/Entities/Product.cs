namespace FortalStore.Domain.StoreContext;

public class Product
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public string Price { get; private set; }
    public string QuantityOnHand { get; private set; }
}