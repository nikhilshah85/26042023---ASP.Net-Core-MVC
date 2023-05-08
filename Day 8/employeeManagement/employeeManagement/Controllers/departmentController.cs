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
    public class departmentController : Controller
    {
        private readonly EmployeeManagementContext _context = new EmployeeManagementContext();

        //public departmentController(EmployeeManagementContext context)
        //{
        //    _context = context;
        //}

        // GET: department
        public async Task<IActionResult> Index()
        {
              return _context.DeptInfos != null ? 
                          View(await _context.DeptInfos.ToListAsync()) :
                          Problem("Entity set 'EmployeeManagementContext.DeptInfos'  is null.");
        }

        // GET: department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeptInfos == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos
                .FirstOrDefaultAsync(m => m.DeptNo == id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            return View(deptInfo);
        }

        // GET: department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptNo,DeptName,DeptCity")] DeptInfo deptInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptInfo);
        }

        // GET: department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeptInfos == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos.FindAsync(id);
            if (deptInfo == null)
            {
                return NotFound();
            }
            return View(deptInfo);
        }

        // POST: department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptNo,DeptName,DeptCity")] DeptInfo deptInfo)
        {
            if (id != deptInfo.DeptNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptInfoExists(deptInfo.DeptNo))
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
            return View(deptInfo);
        }

        // GET: department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeptInfos == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos
                .FirstOrDefaultAsync(m => m.DeptNo == id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            return View(deptInfo);
        }

        // POST: department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeptInfos == null)
            {
                return Problem("Entity set 'EmployeeManagementContext.DeptInfos'  is null.");
            }
            var deptInfo = await _context.DeptInfos.FindAsync(id);
            if (deptInfo != null)
            {
                _context.DeptInfos.Remove(deptInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptInfoExists(int id)
        {
          return (_context.DeptInfos?.Any(e => e.DeptNo == id)).GetValueOrDefault();
        }
    }
}
