using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using employeeManagement.Models.EF;

namespace employeeManagement.Controllers
{
    public class employeeController : Controller
    {
        private readonly EmployeeManagementContext _context = new EmployeeManagementContext();

        //public employeeController(EmployeeManagementContext context)
        //{
        //    _context = context;
        //}

        // GET: employee
        public async Task<IActionResult> Index()
        {
            var employeeManagementContext = _context.EmpInfos.Include(e => e.EmpDeptNoNavigation);
            return View(await employeeManagementContext.ToListAsync());
        }

        // GET: employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmpInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfos
                .Include(e => e.EmpDeptNoNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // GET: employee/Create
        public IActionResult Create()
        {
            ViewData["EmpDeptNo"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo");
            return View();
        }

        // POST: employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpNo,EmpName,EmpDesignation,EmpSalary,EmpDeptNo,EmpIsPermenant")] EmpInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpDeptNo"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo", empInfo.EmpDeptNo);
            return View(empInfo);
        }

        // GET: employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmpInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfos.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound();
            }
            ViewData["EmpDeptNo"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo", empInfo.EmpDeptNo);
            return View(empInfo);
        }

        // POST: employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpNo,EmpName,EmpDesignation,EmpSalary,EmpDeptNo,EmpIsPermenant")] EmpInfo empInfo)
        {
            if (id != empInfo.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpInfoExists(empInfo.EmpNo))
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
            ViewData["EmpDeptNo"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo", empInfo.EmpDeptNo);
            return View(empInfo);
        }

        // GET: employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmpInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.EmpInfos
                .Include(e => e.EmpDeptNoNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // POST: employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmpInfos == null)
            {
                return Problem("Entity set 'EmployeeManagementContext.EmpInfos'  is null.");
            }
            var empInfo = await _context.EmpInfos.FindAsync(id);
            if (empInfo != null)
            {
                _context.EmpInfos.Remove(empInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpInfoExists(int id)
        {
          return (_context.EmpInfos?.Any(e => e.EmpNo == id)).GetValueOrDefault();
        }
    }
}
