using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskingOutAppAPI.Middlewares;
using TaskingOutAppAPI.Data;
using TaskingOutAppAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskingOutAppAPI.Controllers.UserControllers;

public class PostUserController : Controller
{
    [AllowAnonymous]
    [HttpPost("user/")]
    public async Task<IActionResult> PastAsync(
        [FromBody] User UserModel,
        [FromServices] AppDBContext context)
    {
        try
        {
            if (ModelState.IsValid)
            {
                User? usercheck = await context.User.FirstOrDefaultAsync(u => u.Name == UserModel.Name);
                if (usercheck == null)
                {
                    UserModel.Membership = "free";
                    UserModel.EmailConfirmed = false;
                    UserModel.Role = "default";
                    UserModel.Password = PasswordHasher.HashPassword(UserModel.Password);
                    await context.AddAsync(UserModel);
                    await context.SaveChangesAsync();
                    return Created("Usuario criado", null);
                }
                return BadRequest("Usuario já cadastrado");
            }
            return BadRequest(ModelState.Values);
        }
        catch (Exception)
        {
            return (StatusCode(500));
        }
    }
}
