using ToDo.Domain.Enum;
using ToDo.Domain.Models;
using ToDo.Presentation.Contracts.Mappers;
using ToDo.Presentation.Models.Requests;

namespace ToDo.Presentation.Mappers;

public class ToDoItemMapper : IToDoItemMapper
{
    public ToDoItem ToDoItemRequestToModel(ToDoItemRequest toDoItemRequest)
    {
        return new ToDoItem()
        {
            ToDoId = Guid.Empty,
            Category = (Category)toDoItemRequest.Category!,
            Description = toDoItemRequest.Description,
            DeadLine = toDoItemRequest.DeadLine,
            IsCompleted = toDoItemRequest.IsCompleted,
            IsImportant = toDoItemRequest.IsImportant,
            UserId = toDoItemRequest.UserId
        };
    }

    public ToDoItemRequest ToDoItemToRequest(ToDoItem toDoItem)
    {
        return new ToDoItemRequest()
        {
            Category = (int?)toDoItem.Category,
            Description = toDoItem.Description,
            DeadLine = toDoItem.DeadLine,
            IsCompleted = toDoItem.IsCompleted,
            IsImportant = toDoItem.IsImportant,
            UserId = toDoItem.UserId
        };
    }
}