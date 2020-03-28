using MaggieTrainings.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.DataRespository
{
    public class DisciplinesRepository : IDisciplinesRepository
    {
        private readonly IList<TrainingDiscipline> trainingDisciplines;

        public DisciplinesRepository()
        {
            // TODO: Think how these disciplines should actually be stored.
            // Perhaps they should be kept in DB and we should have API o to modify this list
            // For time being this will remian hard-coded

            trainingDisciplines = new List<TrainingDiscipline>
            {
                new TrainingDiscipline() { Id = 1, Description = "Siłownia" },
                new TrainingDiscipline() { Id = 2, Description = "Spacerowanie" },
                new TrainingDiscipline() { Id = 3, Description = "Bieganie" },
                new TrainingDiscipline() { Id = 4, Description = "Basen" },
                new TrainingDiscipline() { Id = 5, Description = "Jazda na rowerze" },
                new TrainingDiscipline() { Id = 6, Description = "Fitness" }
            };
        }

        public async Task<IList<TrainingDiscipline>> GetDisciplines()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(50);
            });

            return trainingDisciplines;
        }

    }
}

