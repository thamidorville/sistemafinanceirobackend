using GerenciamentoFinanceiroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciamentoFinanceiroAPI.Data;


namespace GerenciamentoFinanceiroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReceitasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receitas>>> GetReceitas()
        {
            return await _context.Receitas.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Receitas>> GetReceita(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if(receita == null)
            {
                return NotFound();
            }
            return receita;
        }
        [HttpPost]
        public async Task<ActionResult<Receitas>> PostReceita(Receitas receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReceita), new { id = receita.Id }, receita);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receitas receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            _context.Entry(receita).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
   
}
