using Flunt.Notifications;
using Flunt.Validations;

namespace FortalStore.Domain.StoreContext.ValueObjects;

public class Name : BaseValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(
            new Contract<Name>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "Name.FirstName", "O primeiro nome é obrigatório")
                .IsTrue(FirstName.Length < 30, "Name.FirstName", "Nome maior que 30 caracteres")
                .IsNotNullOrEmpty(LastName, "Name.LastName", "O sobrenome é obrigatório")
                .IsTrue(LastName.Length < 30, "Name.LastName", "Sobrenome maior que 30 caracteres")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}