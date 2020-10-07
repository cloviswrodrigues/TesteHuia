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
    public class PedidoItensController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PedidoItensController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/PedidoItens
        [HttpGet]
        public IEnumerable<PedidoItem> GetPedidoItens()
        {
            return _context.PedidoItens;
        }

        // GET: api/PedidoItens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedidoItem = await _context.PedidoItens.FindAsync(id);

            if (pedidoItem == null)
            {
                return NotFound();
            }

            return Ok(pedidoItem);
        }

        // PUT: api/PedidoItens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoItem([FromRoute] int id, [FromBody] PedidoItem pedidoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoItem.id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoItemExists(id))
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

        // POST: api/PedidoItens
        [HttpPost]
        public async Task<IActionResult> PostPedidoItem([FromBody] PedidoItem pedidoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pedidoItem.produto = _context.Produtos.Find(pedidoItem.produtoid);
            _context.PedidoItens.Add(pedidoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoItem", new { id = pedidoItem.id }, pedidoItem);
        }

        // DELETE: api/PedidoItens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedidoItem = await _context.PedidoItens.FindAsync(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            _context.PedidoItens.Remove(pedidoItem);
            await _context.SaveChangesAsync();

            return Ok(pedidoItem);
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidoItens.Any(e => e.id == id);
        }
    }
}