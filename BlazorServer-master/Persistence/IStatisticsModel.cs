using System.Threading.Tasks;

namespace BlazorServer.Persistence
{
    public interface IStatisticsModel
    {
        Task<int> GetAdultAgeGroupAsync(int minimum, int maximum);

        Task<double> GetEyeColorPercentage(string color);
    }
}