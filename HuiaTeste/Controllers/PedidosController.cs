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
    public class PedidosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PedidosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public IEnumerable<Pedido> GetPedidos()
        {
            return _context.Pedidos.
                        Include(p => p.cliente)
                        .Include(p => p.vendedor)
                        .Include(p => p.pedidoItens);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pedidos.Include(p => p.cliente)
                    .Include(p => p.vendedor)
                    .Include(p => p.pedidoItens).ToList();

            var pedido = await _context.Pedidos.FindAsync(id);        

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpGet("OrderBy/{tipoOrdenacao}")]
        public IEnumerable<Pedido> GetPedidosOrdenado(int tipoOrdenacao)
        {
            _context.Pedidos.Include(p => p.cliente)
                    .Include(p => p.vendedor)
                    .Include(p => p.pedidoItens).ToList();

            if (tipoOrdenacao == 1)
            {
                return _context.Pedidos.OrderBy(x => x.valortotal);
            }
            return _context.Pedidos.OrderBy(x => x.dtcompra);
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido([FromRoute] int id, [FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidos
        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return Ok(pedido);
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.id == id);
        }
    }
}