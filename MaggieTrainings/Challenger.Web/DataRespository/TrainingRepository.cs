using LiteDB;
using MaggieTrainings.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.DataRespository
{
    public class TrainingRepository : ITrainingRepository, IDisposable
    {
        private readonly IHostingEnvironment environment;
        private readonly LiteDatabase dB;
        private readonly LiteCollection<Training> trainingsCollection;

        public TrainingRepository(IHostingEnvironment hostingEnvironment)
        {
            environment = hostingEnvironment;
            dB = new LiteDatabase(GetLiteDbPath());
            trainingsCollection = dB.GetCollection<Training>(nameof(Training));
        }

        private string GetLiteDbPath()
        {
            return environment.ContentRootPath + "\\MaggieTrainings.db";
        }

        public async Task CleanRepository()
        {
            await Task.Run(() =>
            {
                var allTrainings = trainingsCollection.FindAll();

                try
                {
                    foreach (var training in allTrainings)
                    {
                        trainingsCollection?.Delete(training.Id);
                    }
                }
                catch (Exception e)
                {
                    throw new TrainingRepositoryException($"Delete all records failed. Not possible to delete some of records! " +
                        "Details: " + e.ToString());
                }
            });
        }

        public async Task Add(Training training)
        {
            await Task.Run(() =>
            {
                try
                {
                    trainingsCollection.Insert(training);
                }
                catch(Exception e)
                {
                    throw new TrainingRepositoryException($"Could not add new record! Details: " + e.ToString());
                }
            });
        }

        public async Task Remove(Training training)
        {
            await Task.Run(() =>
            {
                try
                {
                    trainingsCollection.Delete(training.Id);
                }
                catch (Exception e)
                {
                    throw new TrainingRepositoryException($"Could not remove record! Details: " + e.ToString());
                }
            });
        }

        public async Task<Training> Get(int id)
        {
            Training foundRecord = null;

            await Task.Run(() =>
            {
                try
                {
                    foundRecord = trainingsCollection.FindById(id);
                }
                catch (Exception e)
                {
                    throw new TrainingRepositoryException($"Could not retrieve record! Details: " + e.ToString());
                }
            });

            return foundRecord;
        }

        public async Task<IList<Training>> GetAll()
        {
            List<Training> foundRecords = null;

            await Task.Run(() =>
            {
                try
                {
                    foundRecords = trainingsCollection.FindAll().ToList();
                }
                catch (Exception e)
                {
                    throw new TrainingRepositoryException($"Could not retrieve records! Details: " + e.ToString());
                }
            });

            return foundRecords;
        }

        public async Task Update(Training training)
        {
            await Task.Run(() =>
            {
                try
                {
                    trainingsCollection.Update(training);
                }
                catch (Exception e)
                {
                    throw new TrainingRepositoryException($"Could not update record! Details: " + e.ToString());
                }
            });
        }

        public void Dispose()
        {
            dB.Dispose();
        }
    }
}
