using ToDo.Domain.Models;
using ToDo.Presentation.Models.Requests;

namespace ToDo.Presentation.Contracts.Mappers;

public interface IToDoItemMapper
{
    public ToDoItem ToDoItemRequestToModel(ToDoItemRequest toDoItemRequest);
    
    public ToDoItemRequest ToDoItemToRequest(ToDoItem toDoItem);
}