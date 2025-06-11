using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Application.Contracts;

public interface IToDoItemService
{
    public Task<OperationResult<ToDoItem[]>> GetItems(Guid userId);
    
    public Task<OperationResult<bool>> CreateOrUpdateItem(ToDoItem toDoItem);
    
    public Task<OperationResult<ToDoItem?>> GetItem(Guid itemId);
    
    public Task<OperationResult<bool>> DeleteItem(Guid itemId);
}