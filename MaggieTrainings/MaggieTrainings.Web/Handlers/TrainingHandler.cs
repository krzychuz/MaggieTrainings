using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using MaggieTrainings.Web.DataRespository.Generics;
using MaggieTrainings.Domain.Models.Data;

namespace MaggieTrainings.Web.Handlers
{
    public class TrainingHandler : ITrainingHandler
    {
        private readonly IGenericRepository<Training> trainingsRepository;

        public TrainingHandler(IUnitOfWork unitOfWork)
        {
            trainingsRepository = unitOfWork.Repository<Training>();
        }

        public void AddTraining(Training training)
        {
            training.AddDate = DateTime.UtcNow;
            training.EditDate = DateTime.UtcNow;

            trainingsRepository.Insert(training);
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
            List<Training> allTrainings = new List<Training>(trainingsRepository.GetAll());

            var dashBoardData = new DashboardData
            {
                NumberOfTrainings = allTrainings.Count,
                LastTraining = allTrainings.OrderBy(training => training.TrainingResult.Date).Last().TrainingResult.Date,
                IsYearlyGoalAchieved = allTrainings.Count >= 100
            };

            return dashBoardData;
        }

        public Training GetTraining(int id)
        {
            return trainingsRepository.GetById(id);
        }

        public void EditTraining(int id, Training training)
        {
            training.EditDate = DateTime.UtcNow;

            trainingsRepository.Edit(training);
        }
    }
}
