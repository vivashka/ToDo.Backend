using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Application.Contracts;

public interface IUserService
{
    public Task<OperationResult<User>> Register(User user);
    
    public Task<OperationResult<User>> Authenticate(string login, string password);
}