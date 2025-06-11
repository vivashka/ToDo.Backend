namespace ToDo.Domain.Models;

public record User
{
    public Guid UserId { get; init; }

    public string Login { get; init; } = string.Empty;
    
    public string Password { get; init; } = string.Empty;
    
    public string FullName { get; init; } = string.Empty;
}