using LiteDB;
using MaggieTrainings.Domain.Models.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void CleanRepository()
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
        }

        public void Add(Training training)
        {
            try
            {
                trainingsCollection.Insert(training);
            }
            catch(Exception e)
            {
                throw new TrainingRepositoryException($"Could not add new record! Details: " + e.ToString());
            }
        }

        public void Remove(Training training)
        {
            try
            {
                trainingsCollection.Delete(training.Id);
            }
            catch (Exception e)
            {
                throw new TrainingRepositoryException($"Could not remove record! Details: " + e.ToString());
            }
        }

        public Training Get(int id)
        {
            Training foundRecord;
            try
            {
                foundRecord = trainingsCollection.FindById(id);
            }
            catch (Exception e)
            {
                throw new TrainingRepositoryException($"Could not retrieve record! Details: " + e.ToString());
            }

            return foundRecord;
        }

        public IList<Training> GetAll()
        {
            List<Training> foundRecords;

            try
            {
                foundRecords = trainingsCollection.FindAll().ToList();
            }
            catch (Exception e)
            {
                throw new TrainingRepositoryException($"Could not retrieve records! Details: " + e.ToString());
            }

            return foundRecords;
        }

        public void Update(Training training)
        {
            try
            {
                trainingsCollection.Update(training);
            }
            catch (Exception e)
            {
                throw new TrainingRepositoryException($"Could not update record! Details: " + e.ToString());
            }
        }

        public void Dispose()
        {
            dB.Dispose();
        }
    }
}
