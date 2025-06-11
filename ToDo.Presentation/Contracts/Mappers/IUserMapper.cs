using ToDo.Domain.Models;
using ToDo.Presentation.Models.Requests;

namespace ToDo.Presentation.Contracts.Mappers;

public interface IUserMapper
{
    public User RegisterRequestToUser(RegisterRequest registerRequest);
    
    public RegisterRequest UserToRegisterRequest(User user);
}