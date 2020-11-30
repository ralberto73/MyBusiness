using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MyBusiness.Models
{
    public partial class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [Display(Name="Brand")]
        public string  BrandName { get; set; }
    }
}
/*
 * [BrandId]
      ,[]
      ,[CreatedBy]
      ,[UpdatedBy]
      ,[CreationDate]
      ,[LastUpdateDate]
*/