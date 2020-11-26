using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MyBusiness.Models
{
    public partial class WorkOrder
    {
        public long WorkOrderId { get; set; }
        [Display(Name = "Status")]
        public string WorkOrderStatusId { get; set; }
        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact information is required")]
        public string MainContat { get; set; }
        [Required(ErrorMessage = "Phone name is required")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public string CretedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdtaedDate { get; set; }
    }
}
