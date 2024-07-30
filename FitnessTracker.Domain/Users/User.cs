using FitnessTracker.Domain.Events;
using SharedKernel;
using SharedKernel.Events;

namespace FitnessTracker.Domain.Users;

public class User : Entity<Guid>
{
    private User(Guid id, Name name,Email email) : base(id)
    {
        Name = name;
        Email = email;
    } 
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    
    public static User Create(Guid id, Name name,Email email)
    {
        var user = new User(id: id, name: name, email: email);
        user.AddDomainEvent(new UserCreatedDomainEvent());
        return user;
    }
}