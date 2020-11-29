using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int ProdCategoryId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

    }
}
