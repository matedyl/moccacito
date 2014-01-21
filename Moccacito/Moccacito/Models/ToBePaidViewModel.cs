using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moccacito.Models
{
    public class ToBePaidViewModel
    {
        public IList<WorkerWithWorkUnitsViewModel> Workers { get; set; }
    }
}