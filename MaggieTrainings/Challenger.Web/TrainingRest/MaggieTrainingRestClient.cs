using MaggieTrainings.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.DataRespository;
using System;
using System.Linq;

namespace MaggieTrainings.Web.TrainingRest
{
    public class MaggieTrainingRestClient : IMaggieTrainingRestClient
    {
        private readonly ITrainingRepository trainingRepository;

        public MaggieTrainingRestClient(ITrainingRepository trainingRepository)
        {
            this.trainingRepository = trainingRepository;
        }

        public async Task AddTraining()
        {
            var newTraining = new Training
            {
                AddDate = DateTime.Now.ToString("f"),
                EditDate = DateTime.Now.ToString("f")
            };
            await trainingRepository.Add(newTraining);
        }

        public async Task ClearTrainingDatabase()
        {
            await trainingRepository.CleanRepository();
        }

        public async Task CreateTrainingDatabase()
        {
            await trainingRepository.InitalizeRepository();
        }

        public async Task<IList<Training>> GetAllTrainings()
        {
            return await trainingRepository.GetAll();
        }

        public async Task<DashboardData> GetDashboardData()
        {
            // TODO - Think if we can performance here

            List<Training> allTrainings = new List<Training>(await trainingRepository.GetAll());

            var dashBoardData = new DashboardData
            {
                NumberOfTrainings = allTrainings.Count,
                LastTraining = allTrainings.Last().AddDate,
            };

            dashBoardData.IsYearlyGoalAchieved = dashBoardData.NumberOfTrainings >= 100;

            return dashBoardData;
        }

        public async Task<Training> GetTraining(int id)
        {
            return await trainingRepository.Get(id);
        }
    }
}
