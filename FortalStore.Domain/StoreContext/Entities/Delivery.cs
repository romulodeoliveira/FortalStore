namespace FortalStore.Domain.StoreContext;

public class Delivery
{
    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDeliveryDate { get; private set; }
    public string Status { get; private set; }
}