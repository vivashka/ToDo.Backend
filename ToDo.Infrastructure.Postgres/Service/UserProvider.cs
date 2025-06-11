using ToDo.Application.Contracts.External;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Postgres.Contracts;

namespace ToDo.Infrastructure.Postgres.Service;

public class UserProvider : IPostgresUserProvider
{
    private readonly IUserRepository _userRepository;

    public UserProvider(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Register(User user, CancellationToken cancellationToken)
    {
        var newUser = _userRepository.Register(user, cancellationToken);

        return newUser;
    }

    public Task<User?> Authenticate(string login, CancellationToken cancellationToken)
    {
        var user = _userRepository.Authenticate(login, cancellationToken);

        return user;
    }
}