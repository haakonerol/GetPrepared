using System.ComponentModel.DataAnnotations;

namespace OppgaveUke2API.Models;

public class Character
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string CharName { get; set; }=string.Empty;
    public int Statment { get; set; }

}