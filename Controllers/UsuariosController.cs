using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JworgApi.Data;
using JworgApi.Models;

namespace JworgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            // Isso vai buscar os dados na tabela 'usuarios' do Railway
            return await _context.usuarios.ToListAsync();
        }
    }
}