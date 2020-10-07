using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Models;

namespace HuiaTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastrosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CadastrosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Cadastros
        [HttpGet]
        public IEnumerable<Cadastro> GetCadastros()
        {
            return _context.Cadastros;
        }

        // GET: api/Cadastros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCadastro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cadastro = await _context.Cadastros.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return Ok(cadastro);
        }

        // PUT: api/Cadastros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastro([FromRoute] int id, [FromBody] Cadastro cadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cadastro.id)
            {
                return BadRequest();
            }

            _context.Entry(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroExists(id))
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

        // POST: api/Cadastros
        [HttpPost]
        public async Task<IActionResult> PostCadastro([FromBody] Cadastro cadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cadastros.Add(cadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastro", new { id = cadastro.id }, cadastro);
        }

        // DELETE: api/Cadastros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            _context.Cadastros.Remove(cadastro);
            await _context.SaveChangesAsync();

            return Ok(cadastro);
        }

        private bool CadastroExists(int id)
        {
            return _context.Cadastros.Any(e => e.id == id);
        }
    }
}