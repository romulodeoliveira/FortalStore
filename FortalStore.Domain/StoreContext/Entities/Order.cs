using FortalStore.Domain.StoreContext.Enums;

namespace FortalStore.Domain.StoreContext.Entities;

public class Order
{
    private readonly IList<OrderItem> _items;
    private readonly IList<Delivery> _deliveries;
    public Order(
        Customer customer)
    {
        Customer = customer;
        CreateDate = DateTime.Now;
        Status = EOrderStatus.Created;
        _items = new List<OrderItem>();
        _deliveries = new List<Delivery>();
    }

    public Customer Customer { get; private set; }
    public string Number { get; private set; }
    public DateTime CreateDate { get; private set; }
    public EOrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
    public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }
    
    public void AddDelivery(Delivery delivery)
    {
        _deliveries.Add(delivery);
    }
    
    // criar um pedido
    public void Place()
    {
        // gera o número do pedido
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

        // validar
    }
    
    // pagar um pedido
    public void Pay()
    {
        Status = EOrderStatus.Paid;
    }
    
    // enviar um pedido
    public void Ship()
    {
        // divide os pedidos em entregas diferentes
        var deliveries = new List<Delivery>();
        deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
        var count = 1;
        foreach (var item in _items)
        {
            if (count == 5)
            {
                count = 1;
                deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            }
            count++;
        }
        
        // envia todas as entregas
        deliveries.ForEach(delivery => delivery.Ship());
        
        // adiciona as entregas aos pedidos 
        deliveries.ForEach(delivery => _deliveries.Add(delivery));
    }
    
    // cancelar um pedido
    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
        _deliveries.ToList().ForEach(delivery => delivery.Cancel());
    }
}