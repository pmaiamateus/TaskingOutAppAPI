using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskingOutAppAPI.Data;
using TaskingOutAppAPI.Models;

namespace TaskingOutAppAPI.Controllers.UserControllers;

public class DeleteUserController : Controller
{
    [AllowAnonymous]
    [HttpDelete("user")]
    public async Task<IActionResult> DeleteAsync(
            [FromBody] User UserInfo,
            [FromServices] AppDBContext context)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var userFromDb = await context.User.FirstOrDefaultAsync(u => u.Email == UserInfo.Email);
                if (userFromDb == null)
                    return BadRequest();
                context.Remove(userFromDb);
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
