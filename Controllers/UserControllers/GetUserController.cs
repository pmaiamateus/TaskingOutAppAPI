using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskingOutAppAPI.Data;
using TaskingOutAppAPI.Models;

namespace TaskingOutAppAPI.Controllers.UserControllers;

public class GetUserController : Controller
{
    [AllowAnonymous]
    [HttpGet("/user/{UserEmail}/")]
    public async Task<IActionResult> GetAsync(
        [FromRoute] string UserEmail,
        [FromServices] AppDBContext context)
    {
        var user = await context
            .User
            .AsNoTracking()
            .Select(x => new User
            {
                Name = x.Name,
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed,
                Role = x.Role,
                Membership = x.Membership,
            })
            .FirstOrDefaultAsync(u => u.Email == UserEmail);
        if (user == null)
            return NotFound(UserEmail);
        return Ok (user);
    }
}
