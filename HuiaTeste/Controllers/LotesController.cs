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
    public class LotesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LotesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Lotes
        [HttpGet]
        public IEnumerable<Lote> GetLotes()
        {
            return _context.Lotes;
        }

        // GET: api/Lotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lote = await _context.Lotes.FindAsync(id);

            if (lote == null)
            {
                return NotFound();
            }

            return Ok(lote);
        }

        // PUT: api/Lotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLote([FromRoute] int id, [FromBody] Lote lote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lote.id)
            {
                return BadRequest();
            }

            _context.Entry(lote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteExists(id))
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

        // POST: api/Lotes
        [HttpPost]
        public async Task<IActionResult> PostLote([FromBody] Lote lote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lotes.Add(lote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLote", new { id = lote.id }, lote);
        }

        // DELETE: api/Lotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            _context.Lotes.Remove(lote);
            await _context.SaveChangesAsync();

            return Ok(lote);
        }

        private bool LoteExists(int id)
        {
            return _context.Lotes.Any(e => e.id == id);
        }
    }
}