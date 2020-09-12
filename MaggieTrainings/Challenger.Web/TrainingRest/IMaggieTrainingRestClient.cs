using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.Models;

namespace MaggieTrainings.Web.TrainingRest
{
    public interface IMaggieTrainingRestClient
    {
        Training GetTraining(int id);

        IList<Training> GetAllTrainings();

        void ClearTrainingDatabase();

        void AddTraining(TrainingResult trainingResult);

        void DeleteTraining(int id);

        void EditTraining(int id, TrainingResult trainingResult);

        DashboardData GetDashboardData();
    }
}