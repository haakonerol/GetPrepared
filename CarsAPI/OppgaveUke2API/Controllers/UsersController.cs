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
        return Ok(await Context.Users.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await Context.Users.FindAsync(id);
        if(user == null)
            return BadRequest("User not found");
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser( User user)
    {
        Context.Add(user);
        await Context.SaveChangesAsync();
        return Ok(await Context.Users.ToListAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User request)
    {
        var user = await Context.Users.FindAsync(id);
        if(user == null)
            return BadRequest("User not found");
        user.Username = request.Username;
        await Context.SaveChangesAsync();
        return Ok(await Context.Users.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<User>>> DeleteUser(int id)
    {
        var user = await Context.Users.FindAsync(id);
        if(user == null)
            return BadRequest("User not found");
        Context.Users.Remove(user);
        await Context.SaveChangesAsync();
        return Ok(await Context.Users.ToListAsync());
    }


}