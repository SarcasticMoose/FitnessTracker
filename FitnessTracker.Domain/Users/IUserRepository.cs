namespace FitnessTracker.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(UserId id, CancellationToken ct = default);
    
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken ct = default);
}