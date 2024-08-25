using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Context;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly NextContext _context;

        public TarefasController(NextContext context)
        {
            _context = context;
        }

        // POST: api/Tarefas/CriarTarefas
        [HttpPost("criar")]
        public async Task<ActionResult<Tarefa>> CriarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterTarefa), new { id = tarefa.Id }, tarefa);
        }

        // GET: api/Tarefas/Listar
        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ListarTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        // GET: api/Tarefas/ObterporID
        [HttpGet("obter/{id}")]
        public async Task<ActionResult<Tarefa>> ObterTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // PUT: api/Tarefas/AtualizarStatus
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Tarefas/EcluirTarefas
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExiste(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
