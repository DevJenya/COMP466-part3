using part3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Services
{
    public class OrderManagement
    {
        public List<Order> GetCustomerOrders(string userID)
        {
            OrderManagementDAO orderManagementDAO = new OrderManagementDAO();
            return orderManagementDAO.GetCustomerOrders(userID);
        }
    }
}