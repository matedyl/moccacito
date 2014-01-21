using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moccacito.Models
{
    public class WorkUnitWithPayment
    {
        [Display(Name = "Czas rozpoczęcia pracy"), DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartTime { get; set; }
        [Display(Name = "Czas zakończenia pracy"), DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EndTime { get; set; }
        [Display(Name = "Do wypłaty"), DataType(DataType.Currency)]
        public double Value { get; set; }
        [Display(Name = "Nazwa lokalizacji")]
        public string LocationName { get; set; }
    }
}