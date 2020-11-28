using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBusiness.DataAccess;
using MyBusiness.Models;

namespace MyBusiness.MVC.Controllers
{
    public class WorkOrdersController : Controller
    {
        private readonly MyBusinessContext _context;

        public WorkOrdersController(MyBusinessContext context)
        {
            _context = context;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {

            //ViewBag.StatusColors = _context.WorkOrderStatuses.ToDictionary(d => new KeyValuePair<string, string>(d.WorkOrderStatusId, d.Color));
            string cnn = @"Data Source=LAPTOP-60J88C7D\LOCALDB;Initial Catalog=MyBusiness;Integrated Security=True;Pooling=False";
            DataRepository da = new DataRepository(cnn);

           // var aaa = da.WorkOrders.DameData(DateTime.Now, DateTime.Now);
            List<WorkOrderListModel>  my_model = da.WorkOrders.DameData( DateTime.Now , DateTime.Now);


            Dictionary<string, string> colors = new Dictionary<string, string>();
            foreach (var a in _context.WorkOrderStatuses) 
            {
                colors.Add(a.WorkOrderStatusId, a.Color);
            }
            ViewBag.StatusColors = colors;
           // my_model
            return View(my_model);
            // return View(await _context.WorkOrders.ToListAsync());
            //  return View( QSOuterJoins);
            //QSOuterJoin
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public IActionResult Create()
        {
            //  Fill  Brands Dropdown List

            ViewData["BrandList"] = _context.Brands.Select(n => new SelectListItem 
                                            {
                                                Value = n.BrandId,
                                                Text = n.BrandId
                                            }).ToList();
           
           
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,WorkOrderStatusId,MainContat,Phone,Email,Brand,Model,Year,Description")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
            ViewData["StatusList"] = _context.WorkOrderStatuses.Select(s => new SelectListItem
            {
                Value = s.WorkOrderStatusId,
                Text =  s.WorkOrderStatusId
            }).ToList();
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("WorkOrderId,WorkOrderStatusId,MainContat,Phone,Email,Brand,Model,Year,Description")] WorkOrder workOrder)
        {
            if (id != workOrder.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workOrder.WorkOrderId))
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
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);
            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderExists(long id)
        {
            return _context.WorkOrders.Any(e => e.WorkOrderId == id);
        }
    }
}
