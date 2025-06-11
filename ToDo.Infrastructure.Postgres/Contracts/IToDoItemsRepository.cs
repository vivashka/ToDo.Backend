using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Infrastructure.Postgres.Contracts;

public interface IToDoItemsRepository
{
    public Task<ToDoItem[]> GetItems(Guid userId, CancellationToken cancellationToken);
    
    public Task<ToDoItem?> CreateOrUpdateItem(ToDoItem toDoItem, CancellationToken cancellationToken);
    
    public Task<ToDoItem?> GetItem(Guid itemId, CancellationToken cancellationToken);
    
    public Task<ToDoItem> DeleteItem(Guid itemId, CancellationToken cancellationToken);
}