
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OppgaveUke2API.Data;
using OppgaveUke2API.Models;

namespace OppgaveUke2API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController: ControllerBase
{
    public ApplicationDbContext Context { get; }

    public CharacterController(ApplicationDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters(){
        return Ok(await Context.Characters.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        var character = await Context.Characters.FindAsync(id);
        if(character == null)
            return NotFound();
        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<Character>> CreateCharacter(Character character)
    {
        Context.Characters.Add(character);
        await Context.SaveChangesAsync();
        return Ok( await Context.Characters.ToListAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Character>> UpdateCharacter(int id, Character request)
    {
        var characterToUpdate = await Context.Characters.FindAsync(id);
        if(characterToUpdate == null)
            return NotFound();
        characterToUpdate.CharName = request.CharName;
        characterToUpdate.Statment = request.Statment;
        await Context.SaveChangesAsync();
        return Ok(await Context.Characters.FindAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> DeleteCharacter(int id)
    {
        var characterToDelete = await Context.Characters.FindAsync(id);
        if(characterToDelete == null)
            return NotFound();
        Context.Characters.Remove(characterToDelete);
        await Context.SaveChangesAsync();
        return Ok(await Context.Characters.ToListAsync());
    }
}