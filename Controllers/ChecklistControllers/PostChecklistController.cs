using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaskingOutAppAPI.Data;
using TaskingOutAppAPI.Models;

namespace TaskingOutAppAPI.Controllers.ChecklistControllers;

public class PostChecklistController : Controller
{
    [AllowAnonymous]
    [HttpPost("/checklist/{UserEmail}")]
    public async Task<IActionResult> PostAsync(
        [FromRoute] string UserEmail,
        [FromBody] Checklist UserChecklist,
        [FromServices] AppDBContext context)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Checklist? ChecklistCheck = await context.Checklists.Include(c => c.User).Include(c => c.CheckTasks).AsNoTracking().FirstOrDefaultAsync(c => c.Id == UserChecklist.Id);
                if (ChecklistCheck == null)
                {
                    ChecklistCheck = UserChecklist;
                    ChecklistCheck.User = await context.User.FirstAsync(u => u.Email == UserEmail);
                    await context.AddAsync(ChecklistCheck);
                    await context.SaveChangesAsync();
                    return Ok(ChecklistCheck);
                }
                return StatusCode(405);
            }
            return BadRequest();
            
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

    }
}
