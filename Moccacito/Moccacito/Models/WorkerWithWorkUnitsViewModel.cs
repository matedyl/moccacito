using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moccacito.Models
{
    public class WorkerWithWorkUnitsViewModel
    {
        public int workerId { get; set; }
        public WorkerViewModel WorkerInfoViewModel { get; set; }
        public List<WorkUnitWithPayment> WorkUnitsWithPayments { get; set; }
        public bool isPaid { get; set; }
    }
}