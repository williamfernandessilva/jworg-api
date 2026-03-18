using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JworgApi.Data;
using JworgApi.Models;

namespace JworgApi.Controllers
{
    // Modelo simples para evitar erro 400 de validação
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Agora usamos 'request.Email' e 'request.Senha'
            var user = await _context.usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.Senha == request.Senha);

            if (user == null)
            {
                return Unauthorized(new { message = "E-mail ou senha incorretos!" });
            }

            return Ok(new { 
                nome = user.Nome, 
                email = user.Email,
                isAdmin = user.IsAdmin 
            });
        }
    }
}