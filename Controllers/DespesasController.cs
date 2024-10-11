using GerenciamentoFinanceiroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciamentoFinanceiroAPI.Data;


namespace GerenciamentoFinanceiroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DespesasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesas>>> GetDespesas()
        {
            return await _context.Despesas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Despesas>> GetDespesa(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            return despesa;
        }

        [HttpPost]
        public async Task<ActionResult<Despesas>> PostDespesa(Despesas despesa)
        {
            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDespesa), new { id = despesa.Id }, despesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesa(int id, Despesas despesa)
        {
            if (id != despesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(despesa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
