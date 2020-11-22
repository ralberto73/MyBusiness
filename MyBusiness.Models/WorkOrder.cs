using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBusiness.Models
{
    public class WorkOrder
    {
        [Key]
        public int    WorkOrderId  { get; set; }
        public string OrderStatusId { get; set; }
        public string OrderDescription { get; set; }

    }
}
