using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBusiness.Models;

namespace MyBusiness.Models
{
    public class ApplicationDbContext : DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       // public DbSet<Brand>     Brands;
       // public DbSet<WorkOrder> WorkOrders;
      //  public DbSet<WorkOrder> WorkOrder { get; set; }
    }
}
