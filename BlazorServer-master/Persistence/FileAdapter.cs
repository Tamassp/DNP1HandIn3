using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorServer.Models;

namespace BlazorServer.Persistence
{
    public class FileAdapter : IFileAdapter, IStatisticsModel
    {
        // private FileContext Context;
        private readonly HttpClient Client;
        private string uri = "https://localhost:5003";

        public FileAdapter()
        {
            // Context = new FileContext();
            Client = new HttpClient();
        }


        public async Task<List<Adult>> GetAdultsAsync()
        {
            Task<string> stringAsync = Client.GetStringAsync(uri + "/adults");
            string message = await stringAsync;
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adults;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultJson, Encoding.UTF8, "application/json");
            await Client.PostAsync(uri + "/adults", content);
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            Task<string> stringAsync = Client.GetStringAsync(uri + $"/adults/{id}");
            string message = await stringAsync;
            Adult adult = JsonSerializer.Deserialize<Adult>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adult;
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
            await Client.DeleteAsync(uri + $"/adults/{adult.Id}");
        }

        public async Task UpdateAsync(Adult adult)
        {
            string adultJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultJson, Encoding.UTF8, "application/json");
            await Client.PatchAsync(uri + "/adults", content);
            
        }

        public async Task<int> GetAdultAgeGroupAsync(int minimum, int maximum)
        {
            string message = await Client.GetStringAsync(uri + $"/statistics?minimum={minimum}&maximum={maximum}");
            int count = int.Parse(message);
            return count;
        }

        public async Task<double> GetEyeColorPercentage(string color)
        {
            string message = await Client.GetStringAsync(uri + $"/statistics/{color}");
            double num = double.Parse(message);
            return num;
        }
    }
}