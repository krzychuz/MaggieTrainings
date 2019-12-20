using System.Collections.Generic;
using System.Threading.Tasks;
using Challenger.Web.Models;

namespace Challenger.Web.TrainingRest
{
    public interface IMaggieTrainingRestClient
    {
        Task<MaggieTrainings> GetTrainingData();

        Task IncreaseTrainingNumber();

        Task CreateTrainingDatabase();
    }
}