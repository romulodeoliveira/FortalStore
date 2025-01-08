using Flunt.Validations;

namespace FortalStore.Domain.StoreContext.ValueObjects;

public class Email : BaseValueObject
{
    public Email(string address)
    {
        Address = address;
        
        AddNotifications(
            new Contract<Email>()
                .Requires()
                .IsEmail(Address, "Email.Address", "Endereço de e-mail inválido")
        );
    }

    public string Address { get; private set; }

    public override string ToString()
    {
        return Address;
    }
}