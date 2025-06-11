using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Application.Contracts.External;

public interface IPostgresUserProvider
{
    public Task<User> Register(User user, CancellationToken cancellationToken);
    
    public Task<User?> Authenticate(string login, CancellationToken cancellationToken);
}