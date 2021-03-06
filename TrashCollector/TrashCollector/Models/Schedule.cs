﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Display(Name = "Default Pickup Day")]
        public string DefaultPickupDay { get; set; }

        [Display(Name = "Start Vacation:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? VacationStartDate { get; set; }

        [Display(Name = "End Vacation:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime? VacationEndDate { get; set; }


    }
}