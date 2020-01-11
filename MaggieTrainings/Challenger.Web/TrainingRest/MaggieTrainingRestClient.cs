﻿using MaggieTrainings.Web.Models;
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
        private readonly IDisciplinesRepository disciplinesRepository;

        public MaggieTrainingRestClient(ITrainingRepository trainingRepository,
            IDisciplinesRepository disciplinesRepository)
        {
            this.trainingRepository = trainingRepository;
            this.disciplinesRepository = disciplinesRepository;
        }

        public async Task AddTraining(TrainingResult trainingResult)
        {
            var newTraining = new Training
            {
                // TODO: AddData and EditData should be culture invariant
                // I should pass pl-PL as CurrentCulture

                AddDate = DateTime.Now.ToString("f"),
                EditDate = DateTime.Now.ToString("f"),
                TrainingResult = trainingResult
            };
            await trainingRepository.Add(newTraining);
        }

        public async Task ClearTrainingDatabase()
        {
            await trainingRepository.CleanRepository();
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

        public async Task<IList<TrainingDiscipline>> GetDisciplines()
        {
            return await disciplinesRepository.GetDisciplines();
        }
    }
}
