using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bankingSolution.Models.EF;

namespace bankingSolution.Controllers
{
    public class branchesController : Controller
    {
        private readonly BankingDbContext _context = new BankingDbContext();

        //public branchesController(BankingDbContext context)
        //{
        //    _context = context;
        //}

        // GET: branches
        public async Task<IActionResult> Index()
        {
              return _context.BranchInfos != null ? 
                          View(await _context.BranchInfos.ToListAsync()) :
                          Problem("Entity set 'BankingDbContext.BranchInfos'  is null.");
        }

        // GET: branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BranchInfos == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos
                .FirstOrDefaultAsync(m => m.BrNo == id);
            if (branchInfo == null)
            {
                return NotFound();
            }

            return View(branchInfo);
        }

        // GET: branches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrNo,BrName,BrCity")] BranchInfo branchInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchInfo);
        }

        // GET: branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BranchInfos == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos.FindAsync(id);
            if (branchInfo == null)
            {
                return NotFound();
            }
            return View(branchInfo);
        }

        // POST: branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrNo,BrName,BrCity")] BranchInfo branchInfo)
        {
            if (id != branchInfo.BrNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchInfoExists(branchInfo.BrNo))
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
            return View(branchInfo);
        }

        // GET: branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BranchInfos == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos
                .FirstOrDefaultAsync(m => m.BrNo == id);
            if (branchInfo == null)
            {
                return NotFound();
            }

            return View(branchInfo);
        }

        // POST: branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BranchInfos == null)
            {
                return Problem("Entity set 'BankingDbContext.BranchInfos'  is null.");
            }
            var branchInfo = await _context.BranchInfos.FindAsync(id);
            if (branchInfo != null)
            {
                _context.BranchInfos.Remove(branchInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchInfoExists(int id)
        {
          return (_context.BranchInfos?.Any(e => e.BrNo == id)).GetValueOrDefault();
        }
    }
}
