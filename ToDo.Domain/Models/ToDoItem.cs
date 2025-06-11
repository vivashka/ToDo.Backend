using ToDo.Domain.Enum;

namespace ToDo.Domain.Models;

public record ToDoItem
{
    public Guid ToDoId { get; init; }

    public string? Description { get; init; } = string.Empty;
    
    public bool? IsCompleted { get; init; }
    
    public bool? IsImportant { get; init; }
    
    public DateTime? DeadLine { get; init; }
    
    public Guid UserId { get; init; }
    
    public Category? Category { get; init; }
}