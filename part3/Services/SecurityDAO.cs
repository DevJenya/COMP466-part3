using part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace part3.Services
{
    public class SecurityDAO
    {
        //returns ID of the user found
        internal int FindByUser(UserModel user)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            int user_ID = -1; // -1 means user doesnt exit

            string queryString = "SELECT * FROM dbo.users WHERE username = '" + user.Username + "' AND password = '" + user.Password + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                user_ID = (int)reader.GetValue(0);
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return user_ID;
        }




        internal bool CheckIfUsernameExists(string username)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            int user_exists = -1; // -1 means user doesnt exit

            string queryString = "SELECT * FROM dbo.users WHERE username = '" + username + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                user_exists = (int)reader.GetValue(0); // returns user ID
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return user_exists >= 0;
        }


        internal void CreateUser(UserModel user)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "Insert into dbo.users ( username, password, email) values ('" + user.Username + "', '" + user.Password + "','" + user.email + "')";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.ExecuteNonQuery();

            cmd.Dispose();
            connection.Close();
        }

        internal string RecoverPassword(UserModel user)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string user_email = "";

            string queryString = "SELECT * FROM dbo.users WHERE username = '" + user.Username + "' AND email = '" + user.email + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                user_email = (string)reader.GetValue(2); // returns user email
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return user_email;
        }

        internal List<Item> QueryItemsAvailable()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT *  FROM dbo.items";
            List<Item> list_of_items = new List<Item>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
            
                list_of_items.Add(new Item((int)reader.GetValue(0), (int)reader.GetValue(1), (string)reader.GetValue(2), (double)reader.GetValue(3), (string)reader.GetValue(4)));
                
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return list_of_items;
        }

        internal Item GetItemById(int id)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT *  FROM dbo.items WHERE id = '" + id + "'";
            Item item = new Item();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader != null && reader.HasRows)
            {
                reader.Read();
                item = new Item((int)reader.GetValue(0), (int)reader.GetValue(1), (string)reader.GetValue(2), (double)reader.GetValue(3), (string)reader.GetValue(4));
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return item;
        }

        internal List<Item> QueryItemsByCategory(int category)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT *  FROM dbo.items WHERE category = '" + category + "'";
            List<Item> list_of_items = new List<Item>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                list_of_items.Add(new Item((int)reader.GetValue(0), (int)reader.GetValue(1), (string)reader.GetValue(2), (double)reader.GetValue(3), (string)reader.GetValue(4)));

            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return list_of_items;
        }

        internal List<Computer_composit> QueryComputersAvailable()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT *  FROM dbo.computers";
            List<Computer_composit> list_of_computers = new List<Computer_composit>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list_of_computers.Add(new Computer_composit((int)reader.GetValue(0), (string)reader.GetValue(1), GetItemById((int)reader.GetValue(3)), GetItemById((int)reader.GetValue(4)), GetItemById((int)reader.GetValue(5)), GetItemById((int)reader.GetValue(6)), GetItemById((int)reader.GetValue(7)), GetItemById((int)reader.GetValue(8)), (string)reader.GetValue(9)));
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return list_of_computers;
        }

        internal void SaveOrder(List<Computer_composit> computer_list, int userId)
        {
            //create order
            //get order id
            //add each item per pc to orderItem

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "Insert into dbo.orderIndex ( userId, numberOfItems) values ('" + userId + "', '" + computer_list.Count +"')";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            //Create order in the OrderIndex table, then get query for the last entry for this user to get the orderID
            SqlCommand cmd = new SqlCommand(queryString, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = cmd;
            adapter.InsertCommand.ExecuteNonQuery();

            //query DB to get order ID
            queryString = "SELECT * FROM dbo.orderIndex WHERE userId = '" + userId + "' ORDER BY orderNumber DESC";
            int orderNumber = -1;

            cmd = new SqlCommand(queryString, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                orderNumber = (int)reader.GetValue(1); // returns OrderID
            }
            reader.Close();

            int index = 0;
            int list_length = computer_list.Count;

            while(index < list_length)
            {
                Computer_composit computer = computer_list[index];
                //Add Computer #Index Ram to the DB
                queryString = "Insert into dbo.orderItem ( orderNumber, computerID, itemID, category, computerName) values ('" + orderNumber + "', '" + index + "', '" + computer.ram.id + "', '" + 1 + "', '" + computer.name + "')";
                cmd = new SqlCommand(queryString, connection);
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();

                //Add Computer #Index Ram to the DB
                queryString = "Insert into dbo.orderItem ( orderNumber, computerID, itemID, category, computerName) values ('" + orderNumber + "', '" + index + "', '"  + computer.harddrive.id + "', '" + 2 + "', '" + computer.name + "')";
                cmd = new SqlCommand(queryString, connection);
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();

                //Add Computer #Index CPU to the DB
                queryString = "Insert into dbo.orderItem ( orderNumber, computerID, itemID, category, computerName) values ('" + orderNumber + "', '" + index + "', '" + computer.cpu.id + "', '" + 3 + "', '" + computer.name + "')";
                cmd = new SqlCommand(queryString, connection);
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();

                //Add Computer #Index Display to the DB
                queryString = "Insert into dbo.orderItem ( orderNumber, computerID, itemID, category, computerName) values ('" + orderNumber + "', '" + index + "', '" + computer.display.id + "', '" + 4 + "', '" + computer.name + "')";
                cmd = new SqlCommand(queryString, connection);
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();

                //Add Computer #Index Ram to the DB
                queryString = "Insert into dbo.orderItem ( orderNumber, computerID, itemID, category, computerName) values ('" + orderNumber + "', '" + index + "', '" + computer.os.id + "', '" + 5 + "', '" + computer.name + "')";
                cmd = new SqlCommand(queryString, connection);
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();

                //Add Computer #Index Ram to the DB
                queryString = "Insert into dbo.orderItem ( orderNumber, computerID, itemID, category, computerName) values ('" + orderNumber + "', '" + index + "', '" + computer.soundcard.id + "', '" + 6 + "', '" + computer.name + "')";
                cmd = new SqlCommand(queryString, connection);
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();

                // add other part implementation
                index++;
            }    
 
            cmd.Dispose();
            connection.Close();
        }
    }
}