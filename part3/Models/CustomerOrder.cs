using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Models
{
    public class CustomerOrder {

        public int orderID { get; set; } = -1;
        public string customerName { get; set ;}
        public DateTime orderDate { get; set; }
    }
}