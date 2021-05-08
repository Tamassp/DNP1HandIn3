using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Authentication
{
    public class UserService : IUserService
    {
        private List<Account> users;

        public UserService()
        {
            users = new[]
            {
                new Account
                {
                    Username = "editor",
                    Password = "pass",
                    Role = "Edit"
                },
                new Account
                {
                    Username = "data",
                    Password = "pass",
                    Role = "Data"
                }
            }.ToList();
        }
        public async Task<Account> ValidateUserAsync(string username, string password)
        {
            Account first = users.FirstOrDefault(user => user.Username.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }
            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
    }
}