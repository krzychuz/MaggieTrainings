﻿using MaggieTrainings.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaggieTrainings.Web.DataRespository;
using System;
using System.Linq;
using System.Globalization;

namespace MaggieTrainings.Web.TrainingRest
{
    public class MaggieTrainingRestClient : IMaggieTrainingRestClient
    {
        private readonly ITrainingRepository trainingRepository;
        private readonly IDisciplinesRepository disciplinesRepository;

        public MaggieTrainingRestClient(ITrainingRepository trainingRepository,
            IDisciplinesRepository disciplinesRepository)
        {
            this.trainingRepository = trainingRepository;
            this.disciplinesRepository = disciplinesRepository;
        }

        public void AddTraining(TrainingResult trainingResult)
        {
            var newTraining = new Training
            {
                // TODO: AddData and EditData should be culture invariant
                // I should pass pl-PL as CurrentCulture

                AddDate = trainingResult.TrainingDate,
                EditDate = DateTime.Now.ToString("f"),
                TrainingResult = trainingResult
            };
            trainingRepository.Add(newTraining);
        }

        public void DeleteTraining(int id)
        {
            var training = trainingRepository.Get(id);
            trainingRepository.Remove(training);
        }

        public void ClearTrainingDatabase()
        {
            trainingRepository.CleanRepository();
        }

        public IList<Training> GetAllTrainings()
        {
            var allTrainings = trainingRepository.GetAll();
            return allTrainings.OrderBy(training => TryParseDate(training.AddDate)).ToList();
        }

        private DateTime TryParseDate(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.ParseExact(dateString, "d.MM.yyyy", CultureInfo.InvariantCulture);
            }
        }

        public DashboardData GetDashboardData()
        {
            // TODO - Think if we can performance here

            List<Training> allTrainings = new List<Training>(trainingRepository.GetAll());

            var dashBoardData = new DashboardData
            {
                NumberOfTrainings = allTrainings.Count,
                LastTraining = allTrainings.OrderBy(training => TryParseDate(training.AddDate)).Last().AddDate,
            };

            dashBoardData.IsYearlyGoalAchieved = dashBoardData.NumberOfTrainings >= 100;

            return dashBoardData;
        }

        public Training GetTraining(int id)
        {
            return trainingRepository.Get(id);
        }

        public IList<TrainingDiscipline> GetDisciplines()
        {
            return disciplinesRepository.GetDisciplines();
        }
    }
}
