using System.ComponentModel.DataAnnotations;

namespace ToDo.Presentation.Models.Requests;

public record RegisterRequest
{
    
    [Required]
    public string Login { get; init; }
    
    [Required]
    public string Password { get; init; } 
    
    [Required]
    public string FullName { get; init; }
}