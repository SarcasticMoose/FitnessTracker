using FitnessTracker.Domain.Users.Events;
using SharedKernel.Entities;

namespace FitnessTracker.Domain.Users;

public class User : Entity
{
    private User(UserId id, Name name, Email email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public UserId Id { get; private set; }
    public Name Name { get; private set; }
    public Email Email { get; private set; }

    public static User Create(UserId id, Name name, Email email)
    {
        var user = new User(id: id, name: name, email: email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent());
        return user;
    }
}