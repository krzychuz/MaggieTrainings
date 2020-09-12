using LiteDB;
using MaggieTrainings.Domain.LegacyModels;
using MaggieTrainings.Domain.Models.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace MaggieTrainings.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            var legacyDbPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\MaggieTrainings.db";
            var legacyDb = new LiteDatabase(legacyDbPath);

            var migratedDbPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\MaggieTrainings_migrated.db";
            var migratedDb = new LiteDatabase(migratedDbPath);

            var disciplineDictionary = new Dictionary<string, int>()
            {
                { "Siłownia", 1 },
                { "Spacerowanie", 2 },
                { "Fitness", 3 },
                { "Bieganie", 4 },
                { "Jazda na rowerze", 5 },
                { "Kajakarstwo", 6 }
            };

            var legacyTrainingCollection = legacyDb.GetCollection<LegacyTraining>("Training");
            var migratedTrainingCollection = migratedDb.GetCollection<Training>();

            foreach(var legacyTraining in legacyTrainingCollection.FindAll())
            {
                var newTraining = new Training
                {
                    Id = legacyTraining.Id,
                    AddDate = TryParseDate(legacyTraining.AddDate),
                    EditDate = TryParseDate(legacyTraining.EditDate),
                    TrainingResult = new TrainingResult
                    {
                        Discipline = new TrainingDiscipline
                        {
                            Id = disciplineDictionary[legacyTraining.TrainingResult.DisciplineName],
                            Description = legacyTraining.TrainingResult.DisciplineName
                        },
                        Duration = legacyTraining.TrainingResult.TrainingDuration,
                        Date = TryParseDate(legacyTraining.TrainingResult.TrainingDate)
                        }
                };

                migratedTrainingCollection.Insert(newTraining);
            }

            var legacyDisciplinesCollection = legacyDb.GetCollection<LegacyTrainingDiscipline>("TrainingDiscipline");
            var migratedDisciplinesCollection = migratedDb.GetCollection<TrainingDiscipline>();

            foreach (var legacyDiscipline in legacyDisciplinesCollection.FindAll())
            {
                var newDiscipline = new TrainingDiscipline
                {
                    Id = legacyDiscipline.Id,
                    Description = legacyDiscipline.Description
                };

                migratedDisciplinesCollection.Insert(newDiscipline);
            }
        }

        public static DateTime TryParseDate(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                try
                {
                    return DateTime.ParseExact(dateString, "d.MM.yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    return DateTime.Parse(dateString);
                }
            }
        }
    }
}
