using System;
using System.Collections.Generic;

#nullable disable

namespace MyBusiness.Models
{
    public partial class WorkOrderDetail
    {
        public long WorkOrderDetailId { get; set; }
        public long WorkOrderId { get; set; }
        public string Description { get; set; }
        public string WorkOrderDetailType { get; set; }
        public decimal ProviderPrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
