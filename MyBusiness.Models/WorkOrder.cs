using System;
using System.Collections.Generic;

#nullable disable

namespace MyBusiness.Models
{
    public partial class WorkOrder
    {
        public long WorkOrderId { get; set; }
        public string WorkOrderStatusId { get; set; }
        public string MainContat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
    }
}
