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
    public class clientController : ControllerBase
    {
        private readonly StockManagementDbContext _context;

        public clientController(StockManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientInfo>>> GetClientInfos()
        {
          if (_context.ClientInfos == null)
          {
              return NotFound();
          }
            return await _context.ClientInfos.ToListAsync();
        }

        // GET: api/client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientInfo>> GetClientInfo(int id)
        {
          if (_context.ClientInfos == null)
          {
              return NotFound();
          }
            var clientInfo = await _context.ClientInfos.FindAsync(id);

            if (clientInfo == null)
            {
                return NotFound();
            }

            return clientInfo;
        }

        // PUT: api/client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientInfo(int id, ClientInfo clientInfo)
        {
            if (id != clientInfo.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(clientInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientInfoExists(id))
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

        // POST: api/client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientInfo>> PostClientInfo(ClientInfo clientInfo)
        {
          if (_context.ClientInfos == null)
          {
              return Problem("Entity set 'StockManagementDbContext.ClientInfos'  is null.");
          }
            _context.ClientInfos.Add(clientInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientInfoExists(clientInfo.ClientId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientInfo", new { id = clientInfo.ClientId }, clientInfo);
        }

        // DELETE: api/client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientInfo(int id)
        {
            if (_context.ClientInfos == null)
            {
                return NotFound();
            }
            var clientInfo = await _context.ClientInfos.FindAsync(id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            _context.ClientInfos.Remove(clientInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientInfoExists(int id)
        {
            return (_context.ClientInfos?.Any(e => e.ClientId == id)).GetValueOrDefault();
        }
    }
}
