namespace TodoApi.Models;

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}