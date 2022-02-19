using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Models
{
    public class Order
    {
        public int userId { get; set; } 
        public int orderNumber { get; set; }
        public int numberOfItems { get; set; }

        public List<Computer_composit> computers_list { get; set; }
        public Order()
        {
            this.computers_list = new List<Computer_composit>();
        }

            public Order(int userId, int orderNumber, int numberOfItems)
        {
            this.userId = userId;
            this.orderNumber = orderNumber;
            this.numberOfItems = numberOfItems;
            this.computers_list = new List<Computer_composit>();
        }
    }
}