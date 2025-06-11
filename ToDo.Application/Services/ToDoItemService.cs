using ToDo.Application.Contracts;
using ToDo.Application.Contracts.External;
using ToDo.Domain.Models;
using ToDo.Shared.OperationResult;

namespace ToDo.Application.Services;

public class ToDoItemService : IToDoItemService
{
    private readonly IPostgresToDoProvider _postgresToDoProvider;

    public ToDoItemService(IPostgresToDoProvider postgresToDoProvider)
    {
        _postgresToDoProvider = postgresToDoProvider;
    }

    public async Task<OperationResult<ToDoItem[]>> GetItems(Guid userId)
    {
        try
        {
            var items = await _postgresToDoProvider.GetItems(userId, CancellationToken.None);

            if (items.Length > 0)
            {
                return OperationResult<ToDoItem[]>.Success(items);
            }
            return new OperationResult<ToDoItem[]>(
                true,
                items, (200, "Не удалось найти заметки"));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return OperationResult<ToDoItem[]>.Failure((400, "Произошла не предвиденная ошибка " + exception.Message));
        }
    }

    public async Task<OperationResult<bool>> CreateOrUpdateItem(ToDoItem toDoItem)
    {
        try
        {
            var item = await _postgresToDoProvider.CreateOrUpdateItem(toDoItem, CancellationToken.None);

            return OperationResult<bool>.Success(true);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return OperationResult<bool>.Failure((400, "Произошла не предвиденная ошибка " + exception.Message));
        }
    }

    public async Task<OperationResult<ToDoItem?>> GetItem(Guid itemId)
    {
        try
        {
            var item = await _postgresToDoProvider.GetItem(itemId, CancellationToken.None);

            if (item.ToDoId != Guid.Empty)
            {
                return OperationResult<ToDoItem?>.Success(item);
            }
            return new OperationResult<ToDoItem?>(
                true,
                item, (200, "Не удалось найти заметку"));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return OperationResult<ToDoItem?>.Failure((400, "Произошла не предвиденная ошибка " + exception.Message));
        }
    }

    public async Task<OperationResult<bool>> DeleteItem(Guid itemId)
    {
        try
        {
            var item = await _postgresToDoProvider.DeleteItem(itemId, CancellationToken.None);

            return OperationResult<bool>.Success(true);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return OperationResult<bool>.Failure((400, "Произошла не предвиденная ошибка " + exception.Message));
        }
    }
}