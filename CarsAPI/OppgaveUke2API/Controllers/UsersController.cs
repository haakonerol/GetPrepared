using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OppgaveUke2API.Data;
using OppgaveUke2API.Models;

namespace OppgaveUke2API.Controllers;

[ApiController]
[Route("/api/users")]
public class UsersController: ControllerBase
{
    public ApplicationDbContext Context { get; }
    public UsersController(ApplicationDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await Context.Users.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser( User user)
    {
        Context.Add(user);
        await Context.SaveChangesAsync();
        return Ok();
    }
}