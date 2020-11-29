using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.MVC.Controllers
{
    public class ProductsController : Controller
    {
        IDataRepository _data_repository;
        public ProductsController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }
        public IActionResult Index()
        {
            List<Product>   all_products =  _data_repository.Products.GetAll();
            return View(all_products);
        }
    }
}
