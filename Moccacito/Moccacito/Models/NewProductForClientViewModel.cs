using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moccacito.Models
{
    public class NewProductForClientViewModel
    {
        public int ClientId { get; set; }
        public String ClientName { get; set; }
        public String ProductName { get; set; }
    }
}