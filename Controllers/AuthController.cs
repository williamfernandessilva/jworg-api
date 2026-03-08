using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JworgApi.Data;
using JworgApi.Models;

namespace JworgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario login)
        {
            // Alterado de .Usuarios para .usuarios (minúsculo) 
            // para bater com o seu AppDbContext atualizado
            var user = await _context.usuarios
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);

            if (user == null)
            {
                return Unauthorized(new { message = "E-mail ou senha incorretos!" });
            }

            return Ok(new { message = "Login realizado com sucesso!", nome = user.Nome });
        }
    }
}