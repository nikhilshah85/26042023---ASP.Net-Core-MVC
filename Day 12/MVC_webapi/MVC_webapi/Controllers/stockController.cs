using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_webapi.Models.EF;

namespace MVC_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stockController : ControllerBase
    {
        private readonly StockManagementDbContext _context;

        public stockController(StockManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockInfo>>> GetStockInfos()
        {
          if (_context.StockInfos == null)
          {
              return NotFound();
          }
            return await _context.StockInfos.ToListAsync();
        }

        // GET: api/stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockInfo>> GetStockInfo(int id)
        {
          if (_context.StockInfos == null)
          {
              return NotFound();
          }
            var stockInfo = await _context.StockInfos.FindAsync(id);

            if (stockInfo == null)
            {
                return NotFound();
            }

            return stockInfo;
        }

        // PUT: api/stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockInfo(int id, StockInfo stockInfo)
        {
            if (id != stockInfo.StockId)
            {
                return BadRequest();
            }

            _context.Entry(stockInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockInfoExists(id))
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

        // POST: api/stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockInfo>> PostStockInfo(StockInfo stockInfo)
        {
          if (_context.StockInfos == null)
          {
              return Problem("Entity set 'StockManagementDbContext.StockInfos'  is null.");
          }
            _context.StockInfos.Add(stockInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockInfoExists(stockInfo.StockId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStockInfo", new { id = stockInfo.StockId }, stockInfo);
        }

        // DELETE: api/stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockInfo(int id)
        {
            if (_context.StockInfos == null)
            {
                return NotFound();
            }
            var stockInfo = await _context.StockInfos.FindAsync(id);
            if (stockInfo == null)
            {
                return NotFound();
            }

            _context.StockInfos.Remove(stockInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockInfoExists(int id)
        {
            return (_context.StockInfos?.Any(e => e.StockId == id)).GetValueOrDefault();
        }
    }
}
