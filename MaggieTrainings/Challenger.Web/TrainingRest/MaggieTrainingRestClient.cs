using MaggieTrainings.Web.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.TrainingRest
{
    public class MaggieTrainingRestClient : IMaggieTrainingRestClient
    {
        public async Task CreateTrainingDatabase()
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(@"C:\Temp\MaggieTrainingData.db"))
                {
                    var col = db.GetCollection<Trainings>(nameof(MaggieTrainings));
                    var maggieTrainings = col.FindAll().FirstOrDefault();
                    if (maggieTrainings == null)
                        col.Insert(CreateNewTrainings());
                    else
                        col.Update(CreateNewTrainings());
                }
            });
        }

        private Trainings CreateNewTrainings()
        {
            return new Trainings
            {
                IsYearlyGoalAchieved = false,
                NumberOfTrainings = 0,
                LastTraining = DateTime.Now
            };
        }
    

        public async Task<Trainings> GetTrainingData()
        {
            Trainings maggieTrainings = null;

            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(@"C:\Temp\MaggieTrainingData.db"))
                {
                    var col = db.GetCollection<Trainings>(nameof(MaggieTrainings));
                    maggieTrainings = col.FindAll().FirstOrDefault();
                }
            });

            return maggieTrainings;
        }

        public async Task IncreaseTrainingNumber()
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(@"C:\Temp\MaggieTrainingData.db"))
                {
                    var col = db.GetCollection<Trainings>(nameof(MaggieTrainings));
                    var maggieTrainings = col.FindAll().FirstOrDefault();
                    if (maggieTrainings == null)
                        throw new Exception("Could not retreive training database!");
                    else
                    {
                        maggieTrainings.NumberOfTrainings += 1;
                        maggieTrainings.LastTraining = DateTime.Now;
                        maggieTrainings.LastTrainingString = maggieTrainings.LastTraining.ToString("f");
                        col.Update(maggieTrainings);
                    }
                }
            });
        }
    }
}
