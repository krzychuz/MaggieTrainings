using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.Models;

namespace MaggieTrainings.Web.TrainingRest
{
    public interface IMaggieTrainingRestClient
    {
        Task<Training> GetTraining(int id);

        Task<IList<Training>> GetAllTrainings();

        Task ClearTrainingDatabase();

        Task AddTraining();

        Task<DashboardData> GetDashboardData();
    }
}