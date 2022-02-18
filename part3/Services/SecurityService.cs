using part3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Services
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }

        public bool UserExists(string username)
        {
            return daoService.CheckIfUsernameExists(username);
        }

        public bool CreateUser(UserModel user)
        {
            if (!UserExists(user.Username))
            {
                daoService.CreateUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RecoverPassword(UserModel user)
        {
                return daoService.RecoverPassword(user);
        }

        public List<Item> GetItems()
        {
            return daoService.QueryItemsAvailable();
        }

        public List<Item> GetItemsByCategory(int category)
        {
            return daoService.QueryItemsByCategory(category);
        }

        public List<Computer_composit> GetComputers()
        {
            return daoService.QueryComputersAvailable();
        }
    }
}