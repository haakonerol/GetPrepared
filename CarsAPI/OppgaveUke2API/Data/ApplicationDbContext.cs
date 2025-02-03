using Microsoft.EntityFrameworkCore;
using OppgaveUke2API.Models;

namespace OppgaveUke2API.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Users> Users { get; set; }
}