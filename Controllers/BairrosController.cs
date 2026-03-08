using JworgApi.Data;
using JworgApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JworgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BairrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bairros (Carrega os pins no mapa)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bairro>>> GetBairros()
        {
            return await _context.bairros.ToListAsync();
        }

        // PUT: api/Bairros/Reservar/5 (Ação do botão no Mapa)
        [HttpPut("Reservar/{id}")]
        public async Task<IActionResult> Reservar(int id)
        {
            var bairro = await _context.bairros.FindAsync(id);

            if (bairro == null) return NotFound();

            if (bairro.Status?.ToLower() == "verde")
            {
                bairro.Status = "amarelo";
                await _context.SaveChangesAsync();
                return Ok(new { message = "Território reservado com sucesso!" });
            }

            return BadRequest("Este território não está disponível para reserva.");
        }
    }
}