using JworgApi.Data;
using JworgApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JworgApi.Controllers
{
    [Route("api/bairros")]
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

        // NOVO MÉTODO: CADASTRAR (Apenas Admin usará no Front)
        [HttpPost]
        public async Task<ActionResult<Bairro>> PostBairro(Bairro bairro)
        {
            // Garante que o bairro novo sempre comece como disponível
            bairro.Status = "verde"; 
            bairro.TrabalhadoPor = null;
            bairro.DataConclusao = null;

            _context.bairros.Add(bairro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBairros), new { id = bairro.Id }, bairro);
        }

        // NOVO MÉTODO: EXCLUIR PIN (Caso cadastre algo errado)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBairro(int id)
        {
            var bairro = await _context.bairros.FindAsync(id);
            if (bairro == null) return NotFound();

            _context.bairros.Remove(bairro);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Pin removido com sucesso!" });
        }

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

        [HttpPut("Concluir/{id}")]
        public async Task<IActionResult> Concluir(int id)
        {
            var bairro = await _context.bairros.FindAsync(id);
            if (bairro == null) return NotFound();

            if (bairro.Status?.ToLower() == "amarelo")
            {
                bairro.Status = "vermelho";
                bairro.DataConclusao = DateTime.Now; 

                _context.Entry(bairro).State = EntityState.Modified;

                try 
                {
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Concluído com sucesso!", data = bairro.DataConclusao });
                }
                catch (Exception ex) 
                {
                    return BadRequest("Erro ao salvar no banco: " + ex.Message);
                }
            }

            return BadRequest("Apenas territórios em andamento podem ser concluídos.");
        }
    }
}