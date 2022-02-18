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
        internal bool FindByUser(UserModel user)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=part4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            int user_exists = -1; // -1 means user doesnt exit

            string queryString = "SELECT * FROM dbo.users WHERE username = '" + user.Username + "' AND password = '" + user.Password + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(queryString, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                user_exists = (int)reader.GetValue(0);
            }

            reader.Close();
            cmd.Dispose();
            connection.Close();

            return user_exists >= 0;
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

    }
}