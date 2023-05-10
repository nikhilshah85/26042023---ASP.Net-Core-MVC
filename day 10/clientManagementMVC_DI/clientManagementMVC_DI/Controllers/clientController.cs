using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clientManagementMVC_DI.Models.EF;

namespace clientManagementMVC_DI.Controllers
{
    public class clientController : Controller
    {
        private readonly ClientManagementContext _context; // do not instantiate the object
                                                           // do not use new keyword


        //object will be created by runtime and injected when this controller will be called
        public clientController(ClientManagementContext context)
        {
            _context = context;
        }

        // GET: client
        public async Task<IActionResult> Index()
        {
              return _context.ClientInfos != null ? 
                          View(await _context.ClientInfos.ToListAsync()) :
                          Problem("Entity set 'ClientManagementContext.ClientInfos'  is null.");
        }

        // GET: client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Clientid == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // GET: client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Clientid,ClientName,ClientLocation,ProjectValue,ClientIsActive")] ClientInfo clientInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientInfo);
        }

        // GET: client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos.FindAsync(id);
            if (clientInfo == null)
            {
                return NotFound();
            }
            return View(clientInfo);
        }

        // POST: client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Clientid,ClientName,ClientLocation,ProjectValue,ClientIsActive")] ClientInfo clientInfo)
        {
            if (id != clientInfo.Clientid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientInfoExists(clientInfo.Clientid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientInfo);
        }

        // GET: client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Clientid == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // POST: client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientInfos == null)
            {
                return Problem("Entity set 'ClientManagementContext.ClientInfos'  is null.");
            }
            var clientInfo = await _context.ClientInfos.FindAsync(id);
            if (clientInfo != null)
            {
                _context.ClientInfos.Remove(clientInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientInfoExists(int id)
        {
          return (_context.ClientInfos?.Any(e => e.Clientid == id)).GetValueOrDefault();
        }
    }
}
