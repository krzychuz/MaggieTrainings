using Challenger.Web.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Web.TrainingRest
{
    public class MaggieTrainingRestClient : IMaggieTrainingRestClient
    {
        public async Task CreateTrainingDatabase()
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(@"C:\Temp\MaggieTrainingData.db"))
                {
                    var col = db.GetCollection<MaggieTrainings>(nameof(MaggieTrainings));
                    var maggieTrainings = col.FindAll().FirstOrDefault();
                    if (maggieTrainings == null)
                        col.Insert(GetNewMaggieTrainings());
                    else
                        col.Update(GetNewMaggieTrainings());
                }
            });
        }

        private MaggieTrainings GetNewMaggieTrainings()
        {
            return new MaggieTrainings
            {
                IsYearlyGoalAchieved = false,
                NumberOfTrainings = 0,
                LastTraining = DateTime.Now
            };
        }
    

        public async Task<MaggieTrainings> GetTrainingData()
        {
            MaggieTrainings maggieTrainings = null;

            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(@"C:\Temp\MaggieTrainingData.db"))
                {
                    var col = db.GetCollection<MaggieTrainings>(nameof(MaggieTrainings));
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
                    var col = db.GetCollection<MaggieTrainings>(nameof(MaggieTrainings));
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
