using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBusiness.Models
{
    public class WorkOrder
    {
        [Key]
        public int    WorkOrderId  { get; set; }

        /// <summary>
        /// /   Order Status
        /// </summary>
        [Required]
        [StringLength(20)]
        [Display(Name = "Status")]
        public string OrderStatusId { get; set; }


        /// <summary>
        ///   Order  Description
        /// </summary>
        [StringLength(250)]
        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar")]
        public string OrderDescription { get; set; }

    }
}
