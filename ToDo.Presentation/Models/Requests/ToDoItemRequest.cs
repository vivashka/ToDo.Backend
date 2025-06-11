namespace ToDo.Presentation.Models.Requests;

public class ToDoItemRequest
{
    public string? Description { get; init; } = string.Empty;
    
    public bool? IsCompleted { get; init; }
    
    public bool? IsImportant { get; init; }
    
    public DateTime? DeadLine { get; init; }
    
    public Guid UserId { get; init; }
    
    public int? Category { get; init; }
}