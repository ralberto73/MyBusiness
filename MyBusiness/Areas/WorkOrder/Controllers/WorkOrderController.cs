using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.Areas.WorkOrder.Controllers
{
    [Area("WorkOrder")]
    public class WorkOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
