using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Data
{
    public class AplicationDBContext : DbContext
    {

        public DbSet<WorkOrder> Rooms { get; set; }
    }
}

//public class SecurityDbContext : IdentityDbContext
//{
//    public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
//        : base(options)
//    {
//    }
//}