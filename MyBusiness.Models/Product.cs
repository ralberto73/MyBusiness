using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int ProdCategoryId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Last Update")]
        public DateTime LastUpdateDate { get; set; }

    }
}
