using part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace part3.Services
{
    public class OrderManagementDAO
    {
        internal List<Order> GetCustomerOrders(string userID)
        {
            Order order = new Order();
            
            List<Order> orders = new List<Order>();
            SecurityService securityService = new SecurityService();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT * FROM dbo.orderIndex WHERE userId = '" + userID + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            //read the list of orders 
            while (reader.Read())
            {
                order.userId = (int)reader.GetValue(0);
                order.orderNumber = (int)reader.GetValue(1);
                order.numberOfItems = (int)reader.GetValue(2);

                orders.Add(new Order((int)reader.GetValue(0), (int)reader.GetValue(1), (int)reader.GetValue(2)));
            }
            reader.Close();

            //go through each order, looks at number of computers => go into each computer, build it and add to the list returned
            for (int i = 0; i < orders.Count; i++)
            {
                for (int k = 0; k < orders[i].numberOfItems; k++)
                {
                    queryString = "SELECT itemID, category, computerName FROM dbo.orderItem WHERE orderNumber = '" + orders[i].orderNumber + "' AND computerID = '" + k + "' ORDER BY category ASC";

                    //queryString = "SELECT itemID, category FROM dbo.orderItem WHERE orderNumber = '13' AND computerID = '0' ORDER BY category ASC";
                    cmd = new SqlCommand(queryString, connection);
                    reader = cmd.ExecuteReader();
                    Computer_composit computer = new Computer_composit();
                    //build the PC
                    while (reader.Read())
                    {
                        int itemID = (int)reader.GetValue(0);
                        int category = (int)reader.GetValue(1);
                        

                        switch (category)
                        {
                            case 1:
                                computer.ram = securityService.GetItemByID(itemID);
                                computer.name = (string)reader.GetValue(2);
                                break;
                            case 2:
                                computer.harddrive = securityService.GetItemByID(itemID);
                                break;
                            case 3:
                                computer.cpu = securityService.GetItemByID(itemID);
                                break;
                            case 4:
                                computer.display = securityService.GetItemByID(itemID);
                                break;
                            case 5:
                                computer.os = securityService.GetItemByID(itemID);
                                break;
                            default:
                                computer.soundcard = securityService.GetItemByID(itemID);
                                break;
                        }
                    }
                    computer.calculatePrice();
                    orders[i].computers_list.Add(computer);
                    reader.Close();
                }               
            }
            reader.Close();
            cmd.Dispose();
            connection.Close();

            return orders;
        }

        internal void RemoveOrder(int orderNumber)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "DELETE FROM dbo.orderItem WHERE orderNumber = '" + orderNumber + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(queryString, connection);
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.ExecuteNonQuery();

            queryString = "DELETE FROM dbo.orderIndex WHERE orderNumber = '" + orderNumber + "'";
            adapter = new SqlDataAdapter();
            cmd = new SqlCommand(queryString, connection);
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.ExecuteNonQuery();

            cmd.Dispose();
            connection.Close();
        }
    }
}