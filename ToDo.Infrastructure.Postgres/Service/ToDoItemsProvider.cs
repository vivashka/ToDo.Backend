using System.Text;
using ToDo.Application.Contracts.External;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Postgres.Contracts;
using ToDo.Shared.OperationResult;

namespace ToDo.Infrastructure.Postgres.Service;

public class ToDoItemsProvider : IPostgresToDoProvider
{
    private readonly IToDoItemsRepository _toDoItemsRepository;

    public ToDoItemsProvider(IToDoItemsRepository toDoItemsRepository)
    {
        _toDoItemsRepository = toDoItemsRepository;
    }

    public async Task<ToDoItem[]> GetItems(Guid userId, CancellationToken cancellationToken)
    {
        var items = await _toDoItemsRepository.GetItems(userId, cancellationToken);
        
        return items;
    }

    public async Task<ToDoItem?> CreateOrUpdateItem(ToDoItem toDoItem, CancellationToken cancellationToken)
    {
        var newItem = await _toDoItemsRepository.CreateOrUpdateItem(toDoItem, cancellationToken);
        
        return newItem;
    }

    public async Task<ToDoItem?> GetItem(Guid itemId, CancellationToken cancellationToken)
    {
        var item = await _toDoItemsRepository.GetItem(itemId, cancellationToken);

        return item;
    }

    public async Task<ToDoItem> DeleteItem(Guid itemId, CancellationToken cancellationToken)
    {
        var item = await _toDoItemsRepository.DeleteItem(itemId, cancellationToken);
        
        return item;
    }
}