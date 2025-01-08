using Flunt.Notifications;
using Flunt.Validations;

namespace FortalStore.Domain.StoreContext.Entities;

public class OrderItem : BaseEntity
{
    public OrderItem(
        Product product, 
        decimal quantity)
    {
        Product = product;
        Quantity = quantity;
        Price = product.Price;
        
        AddNotifications(
            new Contract<OrderItem>()
                .Requires()
                .IsTrue(product.QuantityOnHand < quantity, "Quantity", "Produto fora de estoque.")
        );
    }

    public Product Product { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
}