using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskingOutAppAPI.Data;
using TaskingOutAppAPI.Middlewares;
using TaskingOutAppAPI.Models;

namespace TaskingOutAppAPI.Controllers.UserControllers;

public class PutUserController : Controller
{
    [AllowAnonymous]
    [HttpPut("user")]
    public async Task<IActionResult> PutAsync(
            [FromBody] User UserModel,
            [FromServices] AppDBContext context)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var UserFromDB = await context.User.FirstOrDefaultAsync(u => u.Email == UserModel.Email);
                UserFromDB.Name = UserModel.Name;
                UserFromDB.Password = PasswordHasher.HashPassword(UserModel.Password);
                context.Update(UserFromDB);
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(UserModel);

        }
        catch (Exception)
        {
            return (UnprocessableEntity());
        }
    }
}
