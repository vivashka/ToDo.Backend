using Dapper;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Postgres.Contracts;
using ToDo.Shared.OperationResult;

namespace ToDo.Infrastructure.Postgres.Repository;

public class ToDoItemsRepository : BaseRepository, IToDoItemsRepository
{
    public async Task<ToDoItem[]> GetItems(Guid userId, CancellationToken cancellationToken)
    {
        string sqlRequest = """
                            SELECT *
                            FROM "ToDoItems"
                            WHERE "UserId" = @UserId
                            """;

        var param = new DynamicParameters();
        param.Add("UserId", userId);

        return await ExecuteQueryAsync<ToDoItem>(sqlRequest, param, cancellationToken);
    }

    public async Task<ToDoItem?> CreateOrUpdateItem(ToDoItem toDoItem, CancellationToken cancellationToken)
    {
        Guid toDoId = toDoItem.ToDoId != Guid.Empty ? toDoItem.ToDoId : Guid.NewGuid();
        
        string sqlRequest = """
                            INSERT INTO "ToDoItems" td
                            VALUES (@ToDoId, @Description, @IsCompeted, @IsImportant, @Deadline, @UserId, @Category)
                                ON CONFLICT ("ToDoId")
                            DO UPDATE SET
                                "Description" = COALESCE(EXCLUDED."Description", td."Description"),
                                "IsCompeted" = COALESCE(EXCLUDED."IsCompeted", td."IsCompeted"),
                                "IsImportant" = COALESCE(EXCLUDED."IsImportant", td."IsImportant"),
                                "Deadline" = COALESCE(EXCLUDED."Deadline", td."Deadline"),
                                "Category" = COALESCE(EXCLUDED."Category", td."Category")
                            RETURNING *;
                            """;

        var param = new DynamicParameters(toDoItem);
        param.Add("ToDoId", toDoId);

        return await ExecuteNonQueryAsync<ToDoItem>(sqlRequest, param, cancellationToken);
    }

    public async Task<ToDoItem?> GetItem(Guid itemId, CancellationToken cancellationToken)
    {
        string sqlRequest = """
                            SELECT *
                            FROM "ToDoItems"
                            WHERE "ItemId" = @ItemId
                            """;

        var param = new DynamicParameters();
        param.Add("ItemId", itemId);

        return await ExecuteNonQueryAsync<ToDoItem>(sqlRequest, param, cancellationToken);
    }

    public async Task<ToDoItem> DeleteItem(Guid itemId, CancellationToken cancellationToken)
    {
        string sqlRequest = """
                            DELETE FROM "ToDoItems"
                            WHERE "ItemId" = @ItemId
                            RETURNING *;
                            """;

       
        var param = new DynamicParameters();
        param.Add("ItemId", itemId);
        
        return await ExecuteQuerySingleAsync<ToDoItem>(sqlRequest, param, cancellationToken);
    }
}