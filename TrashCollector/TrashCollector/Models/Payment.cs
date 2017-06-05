using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    [Table("Payment")]
    public class Payment
    {

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Display(Name = "Credit Card Info")]
        public string PaymentInfo { get; set; }

        [Display(Name = "Current Bill")]
        public double? CurrentBill { get; set; }

    }
}