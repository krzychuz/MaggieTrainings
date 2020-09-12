using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Domain.Models;
using MaggieTrainings.Domain.Models.Data;

namespace MaggieTrainings.Web.TrainingRest
{
    public interface ITrainingHandler
    {
        Training GetTraining(int id);

        IList<Training> GetAllTrainings();

        void AddTraining(Training trainingResult);

        void DeleteTraining(int id);

        void EditTraining(int id, Training trainingResult);

        DashboardData GetDashboardData();
    }
}