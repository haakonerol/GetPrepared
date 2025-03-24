using System.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace TodoApi.Models;

public class TodoItemDto
{

    public int Id { get; set; }
    public string? Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}