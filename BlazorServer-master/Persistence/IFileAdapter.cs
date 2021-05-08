using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServer.Models;

namespace BlazorServer.Persistence
{
    public interface IFileAdapter
    {
        Task<List<Adult>> GetAdultsAsync();
        Task AddAdultAsync(Adult adult);
        Task<Adult> GetAdultAsync(int id);
        Task RemoveAdultAsync(Adult adult);
        Task UpdateAsync(Adult adult);
    }
}