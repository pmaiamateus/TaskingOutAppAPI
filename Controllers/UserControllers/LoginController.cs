using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TaskingOutAppAPI.Data;
using TaskingOutAppAPI.Models;
using TaskingOutAppAPI.Middlewares;

namespace TaskingOutAppAPI.Controllers.UserControllers;

public class LoginController : Controller
{
    [AllowAnonymous]
    [HttpPost("user/login")]
    public async Task<IActionResult> GetAsync(
        [FromBody] User UserInfo,
        [FromServices] AppDBContext context)
    {
        try
        {
            {
                User? user = await context.User.FirstOrDefaultAsync(u => u.Email == UserInfo.Email);
                if (user == null)
                    return NotFound("email inválidos");
                var passwordVerify = PasswordHasher.VerifyHash(UserInfo.Password, user.Password);
                if (passwordVerify == false)
                    return NotFound("Senha ou email inválidos");
                return Ok();
            }
        }
        catch (Exception)
        {
            return (StatusCode(500));
        }
    }
}
