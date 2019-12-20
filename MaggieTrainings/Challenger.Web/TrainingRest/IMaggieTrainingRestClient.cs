using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.Models;

namespace MaggieTrainings.Web.TrainingRest
{
    public interface IMaggieTrainingRestClient
    {
        Task<Trainings> GetTrainingData();

        Task IncreaseTrainingNumber();

        Task CreateTrainingDatabase();
    }
}