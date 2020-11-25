using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBusiness.Models;

namespace MyBusiness.MVC.Controllers
{
    public class WorkOrderStatusController : Controller
    {
        private readonly MyBusinessContext _context;

        public WorkOrderStatusController(MyBusinessContext context)
        {
            _context = context;
        }

        // GET: WorkOrderStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderStatuses.ToListAsync());
        }

        // GET: WorkOrderStatus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderStatus = await _context.WorkOrderStatuses
                .FirstOrDefaultAsync(m => m.WorkOrderStatusId == id);
            if (workOrderStatus == null)
            {
                return NotFound();
            }

            return View(workOrderStatus);
        }

        // GET: WorkOrderStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderStatusId,StatusDescription,Color")] WorkOrderStatus workOrderStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderStatus);
        }

        // GET: WorkOrderStatus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderStatus = await _context.WorkOrderStatuses.FindAsync(id);
            if (workOrderStatus == null)
            {
                return NotFound();
            }
            return View(workOrderStatus);
        }

        // POST: WorkOrderStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WorkOrderStatusId,StatusDescription,Color")] WorkOrderStatus workOrderStatus)
        {
            if (id != workOrderStatus.WorkOrderStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderStatusExists(workOrderStatus.WorkOrderStatusId))
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
            return View(workOrderStatus);
        }

        // GET: WorkOrderStatus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderStatus = await _context.WorkOrderStatuses
                .FirstOrDefaultAsync(m => m.WorkOrderStatusId == id);
            if (workOrderStatus == null)
            {
                return NotFound();
            }

            return View(workOrderStatus);
        }

        // POST: WorkOrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workOrderStatus = await _context.WorkOrderStatuses.FindAsync(id);
            _context.WorkOrderStatuses.Remove(workOrderStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderStatusExists(string id)
        {
            return _context.WorkOrderStatuses.Any(e => e.WorkOrderStatusId == id);
        }
    }
}
