using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoItem
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string? Title { get; set; }
    [MaxLength(90)]
    public string Description { get; set; } = string.Empty;
    public int Priority { get; set; } // Low:-1, Normal:0, High:1
    [Required]
    [DefaultValue(false)]
    public bool IsComplete { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}