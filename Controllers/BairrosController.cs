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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bairro>>> GetBairros()
        {
            return await _context.bairros.ToListAsync();
        }

        // MÉTODO RESERVAR (Verde -> Amarelo)
        [HttpPut("Reservar/{id}")]
        public async Task<IActionResult> Reservar(int id, [FromBody] string nomeUsuario)
        {
            var bairro = await _context.bairros.FindAsync(id);
            if (bairro == null) return NotFound();

            if (bairro.Status?.ToLower() == "verde")
            {
                bairro.Status = "amarelo";
                bairro.TrabalhadoPor = nomeUsuario; 
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Reservado para {nomeUsuario}" });
            }
            return BadRequest("Território indisponível.");
        }

        // MÉTODO CONCLUIR (Amarelo -> Vermelho + DATA)
        [HttpPut("Concluir/{id}")]
public async Task<IActionResult> Concluir(int id)
{
    var bairro = await _context.bairros.FindAsync(id);
    if (bairro == null) return NotFound();

    if (bairro.Status?.ToLower() == "amarelo")
    {
        bairro.Status = "vermelho";
        bairro.DataConclusao = DateTime.Now; // Pega a data e hora atual

        // Força o Entity Framework a entender que o bairro mudou
        _context.Entry(bairro).State = EntityState.Modified;

        try 
        {
            await _context.SaveChangesAsync();
            return Ok(new { message = "Concluído com sucesso!", data = bairro.DataConclusao });
        }
        catch (Exception ex) 
        {
            // Se der erro no banco, aparecerá no seu terminal do VS Code
            return BadRequest("Erro ao salvar no banco: " + ex.Message);
        }
    }

    return BadRequest("Apenas territórios em andamento podem ser concluídos.");
}
    }
}