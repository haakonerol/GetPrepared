using System.ComponentModel.DataAnnotations;

namespace OppgaveUke2API.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Username { get; set; }
    public int CharacterId { get; set; }
}