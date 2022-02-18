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
        public int computerId { get; set; }
        public string computerName { get; set; }
        public double ComputerPrice { get; set; }
        public int ramID { get; set; }
        public int harddriveID { get; set; }
        public int cpuID { get; set; }
        public int displayID { get; set; }
        public int osID { get; set; }
        public int soundcardID { get; set; }

        public CustomerOrder() { }
        public CustomerOrder(int orderID, string customerName, DateTime orderDate, int computerId, string computerName, double computerPrice, int ramID, int harddriveID, int cpuID, int displayID, int osID, int soundcardID)
        {
            this.orderID = orderID;
            this.customerName = customerName;
            this.orderDate = orderDate;
            this.computerId = computerId;
            this.computerName = computerName;
            ComputerPrice = computerPrice;
            this.ramID = ramID;
            this.harddriveID = harddriveID;
            this.cpuID = cpuID;
            this.displayID = displayID;
            this.osID = osID;
            this.soundcardID = soundcardID;
        }
    }
}