using ToDo.Domain.Models;
using ToDo.Presentation.Contracts.Mappers;
using ToDo.Presentation.Models.Requests;

namespace ToDo.Presentation.Mappers;

public class UserMapper : IUserMapper
{
    public User RegisterRequestToUser(RegisterRequest registerRequest)
    {
        return new User()
        {
            UserId = Guid.Empty,
            Login = registerRequest.Login,
            Password = registerRequest.Password,
            FullName = registerRequest.FullName
        };
    }

    public RegisterRequest UserToRegisterRequest(User user)
    {
        return new RegisterRequest()
        {
            Login = user.Login,
            Password = user.Password,
            FullName = user.FullName
        };
    }
}