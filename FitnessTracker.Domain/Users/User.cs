﻿using FitnessTracker.Domain.Events;
using SharedKernel;
using SharedKernel.Entities;
using SharedKernel.Events;

namespace FitnessTracker.Domain.Users;

public class User : Entity<UserId>
{
    private User(UserId id, Name name,Email email) : base(id)
    {
        Name = name;
        Email = email;
    } 
    
    public Name Name { get; private set; }
    
    public Email Email { get; private set; }
    
    public static User Create(UserId id, Name name,Email email)
    {
        var user = new User(id: id, name: name, email: email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent());
        return user;
    }
}