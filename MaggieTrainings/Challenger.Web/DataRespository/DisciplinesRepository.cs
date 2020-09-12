﻿using LiteDB;
using MaggieTrainings.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.DataRespository
{
    public class DisciplinesRepository : IDisciplinesRepository
    {
        private readonly IHostingEnvironment environment;
        private readonly LiteDatabase dB;
        private readonly LiteCollection<TrainingDiscipline> trainingsCollection;

        public DisciplinesRepository(IHostingEnvironment hostingEnvironment)
        {
            environment = hostingEnvironment;
            dB = new LiteDatabase(GetLiteDbPath());
            trainingsCollection = dB.GetCollection<TrainingDiscipline>(nameof(TrainingDiscipline));
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

        public void Add(TrainingDiscipline training)
        {
            try
            {
                trainingsCollection.Insert(training);
            }
            catch (Exception e)
            {
                throw new TrainingRepositoryException($"Could not add new record! Details: " + e.ToString());
            }
        }

        public void Remove(int id)
        {
            try
            {
                trainingsCollection.Delete(id);
            }
            catch (Exception e)
            {
                throw new TrainingRepositoryException($"Could not remove record! Details: " + e.ToString());
            }
        }

        public TrainingDiscipline Get(int id)
        {
            TrainingDiscipline foundRecord;
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

        public IList<TrainingDiscipline> GetAll()
        {
            List<TrainingDiscipline> foundRecords;

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

        public void Update(TrainingDiscipline training)
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
