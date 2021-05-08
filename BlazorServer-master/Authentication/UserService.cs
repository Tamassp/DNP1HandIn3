using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorServer.Models;

namespace BlazorServer.Authentication
{
    public class UserService : IUserService
    {
        private readonly HttpClient Client;
        private string uri = "https://localhost:5003";

        public UserService()
        {
            Client = new HttpClient();
        }
        
        // private List<Account> users;
        //
        // public UserService()
        // {
        //     users = new[]
        //     {
        //         new Account
        //         {
        //             Username = "editor",
        //             Password = "pass",
        //             Role = "Edit"
        //         },
        //         new Account
        //         {
        //             Username = "data",
        //             Password = "pass",
        //             Role = "Data"
        //         }
        //     }.ToList();
        // }
        public async Task<Account> ValidateUserAsync(string username, string password)
        {
            try
            {
                string stringAsync = await Client.GetStringAsync(uri + $"/authentication?username={username}&password={password}");
                Account account = JsonSerializer.Deserialize<Account>(stringAsync, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return account;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
            // Account first = users.FirstOrDefault(user => user.Username.Equals(username));
            // if (first == null)
            // {
            //     throw new Exception("User not found");
            // }
            // if (!first.Password.Equals(password))
            // {
            //     throw new Exception("Incorrect password");
            // }
            // return first;
        }
    }
}