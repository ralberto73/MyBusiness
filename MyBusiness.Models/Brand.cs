using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Models
{
    public class Brand
    {
        [Key]
        public string BrandId;

        public string Description;
    }
}
