using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.DataAcces
{
    public class DBContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Adult> Adults { get; set; }
        //public DbSet<Job> Jobs { get; set; }   
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQlite database
            optionsBuilder.UseSqlite("Data Source = HandInFamily.db");
        }

        public Task<IList<Adult>> GetAdultsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        { 
            /*Add(adult);
            SaveChanges();*/
            int id = Adults.Max(max => max.Id) + 1;
            adult.Id = id;
            Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            string idS = id.ToString();
            return Adults.First(a => a.Id.Equals(idS));
        }

        public async Task RemoveAdultAsync(int id)
        {
            string idS = id.ToString();
            Adult delete = Adults.First(a => a.Id.Equals(idS));
            Adults.Remove(delete);
            SaveChanges();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult ad = Adults.First(a => a.Id == adult.Id);
            ad.FirstName = adult.FirstName;
            ad.LastName = adult.LastName;
            ad.Age = adult.Age;
            ad.Height = adult.Height;
            ad.Weight = adult.Weight;
            ad.EyeColor = adult.EyeColor;
            ad.Sex = adult.Sex;
            ad.HairColor = adult.HairColor;
            ad.Id = adult.Id;
            SaveChanges();
            return ad;
        }
    }
}