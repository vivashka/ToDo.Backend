using System.Security.Cryptography;
using System.Text;
using ToDo.Application.Contracts;
using ToDo.Application.Contracts.External;
using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Application.Services;

public class UserService : IUserService
{
    private readonly IPostgresUserProvider _postgresUserProvider;

    public UserService(IPostgresUserProvider postgresUserProvider)
    {
        _postgresUserProvider = postgresUserProvider;
    }

    public async Task<OperationResult<User>> Register(User user)
    {
        try
        {
            var newUser = await _postgresUserProvider.Register(user, CancellationToken.None);

            return OperationResult<User>.Success(newUser);
        }
        catch (Exception exception)
        {
            return OperationResult<User>.Failure((400, "Произошла непредвиденная ошибка" + exception.Message));
        }
    }

    public async Task<OperationResult<User>> Authenticate(string login, string password)
    {
        try
        {
            var user = await _postgresUserProvider.Authenticate(login, CancellationToken.None);
            var curHash = CreateMd5(password + login, Encoding.GetEncoding(866));
            
            if (user.Password == curHash)
            {
                return OperationResult<User>.Success(user);
            }
            return OperationResult<User>.Failure((200, "Не верный пароль"));
           
        }
        catch (Exception exception)
        {
            return OperationResult<User>.Failure((400, "Произошла непредвиденная ошибка" + exception.Message));
        }
    }
    
    private static string CreateMd5(string text, Encoding encoding)
    {
        var inputBytes = encoding.GetBytes(text);

        var hashBytes = MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}