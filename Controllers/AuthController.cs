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
            // Busca o usuário no banco (tabela 'usuarios' em minúsculo conforme seu DbContext)
            var user = await _context.usuarios
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);

            if (user == null)
            {
                return Unauthorized(new { message = "E-mail ou senha incorretos!" });
            }

            // Retorna os dados para o React salvar no localStorage
            return Ok(new { 
                nome = user.Nome, 
                email = user.Email,
                isAdmin = user.IsAdmin 
            });
        } // Fechamento do Método Login
    } // Fechamento da Classe AuthController
} // Fechamento do Namespace