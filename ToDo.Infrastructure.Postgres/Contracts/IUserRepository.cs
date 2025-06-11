using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Infrastructure.Postgres.Contracts;

public interface IUserRepository
{
    public Task<User> Register(User user, CancellationToken cancellationToken);
    
    public Task<User?> Authenticate(string login, CancellationToken cancellationToken);
}