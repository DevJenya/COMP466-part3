using part3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Services
{
    public class OrderManagement
    {
        OrderManagementDAO orderManagementDAO = new OrderManagementDAO();
        public List<Order> GetCustomerOrders(string userID)
        {
            return orderManagementDAO.GetCustomerOrders(userID);
        }

        //removes order from orderIndex and orderItem tables with that orderNumber
        public void RemoveOrder(int orderNumber)
        {
            orderManagementDAO.RemoveOrder(orderNumber);
        }
    }
}