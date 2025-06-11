using Dapper;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Postgres.Contracts;
using ToDo.Shared.OperationResult;

namespace ToDo.Infrastructure.Postgres.Repository;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<User> Register(User user, CancellationToken cancellationToken)
    {
        Guid userId = Guid.NewGuid();
        
        string sqlRequest = """
                            INSERT INTO "Users" td
                            VALUES (@UserId, @Login, @Password, @FullName)
                            RETURNING *;
                            """;

        var param = new DynamicParameters(user);
        param.Add("ToDoId", userId);

        return await ExecuteNonQueryAsync<User>(sqlRequest, param, cancellationToken) ?? throw new InvalidOperationException();
    }

    public async Task<User?> Authenticate(string login, CancellationToken cancellationToken)
    {
        string sqlRequest = """
                            SELECT *
                            FROM "Users"
                            WHERE "Login" = @Login
                            """;

        var param = new DynamicParameters();
        param.Add("Login", login);

        return await ExecuteNonQueryAsync<User>(sqlRequest, param, cancellationToken);
    }
}