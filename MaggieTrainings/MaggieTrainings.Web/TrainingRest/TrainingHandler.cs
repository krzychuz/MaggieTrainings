using MaggieTrainings.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.DataRespository;
using System;
using System.Linq;
using System.Globalization;
using MaggieTrainings.Web.DataRespository.Generics;

namespace MaggieTrainings.Web.TrainingRest
{
    public class TrainingHandler : ITrainingHandler
    {
        private readonly IGenericRepository<Training> trainingsRepository;

        public TrainingHandler(IUnitOfWork unitOfWork)
        {
            trainingsRepository = unitOfWork.Repository<Training>();
        }

        public void AddTraining(TrainingResult trainingResult)
        {
            var newTraining = new Training
            {
                AddDate = trainingResult.Date,
                EditDate = DateTime.UtcNow,
                TrainingResult = trainingResult
            };
            trainingsRepository.Insert(newTraining);
        }

        public void DeleteTraining(int id)
        {
            trainingsRepository.Delete(id);
        }


        public IList<Training> GetAllTrainings()
        {
            var allTrainings = trainingsRepository.GetAll();
            return allTrainings.OrderByDescending(training => training.TrainingResult.Date).ToList();
        }

        public DashboardData GetDashboardData()
        {
            // TODO - Think if we can performance here

            List<Training> allTrainings = new List<Training>(trainingsRepository.GetAll());

            var dashBoardData = new DashboardData
            {
                NumberOfTrainings = allTrainings.Count,
                LastTraining = allTrainings.OrderBy(training => training.TrainingResult.Date).Last().TrainingResult.Date,
            };

            dashBoardData.IsYearlyGoalAchieved = dashBoardData.NumberOfTrainings >= 100;

            return dashBoardData;
        }

        public Training GetTraining(int id)
        {
            return trainingsRepository.GetById(id);
        }

        public void EditTraining(int id, TrainingResult trainingResult)
        {
            var training = GetTraining(id);

            training.EditDate = DateTime.UtcNow;
            training.TrainingResult = trainingResult;

            trainingsRepository.Edit(training);
        }
    }
}
