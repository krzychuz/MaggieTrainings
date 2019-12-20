using LiteDB;
using System;

namespace Challenger.Web.Models
{
    public class MaggieTrainings
    {
        [BsonId]
        public int ObjectId { get; set; }

        [BsonField]
        public int NumberOfTrainings { get; set; }

        [BsonField]
        public DateTime LastTraining { get; set; }

        [BsonField]
        public string LastTrainingString { get; set; }

        [BsonField]
        public bool IsYearlyGoalAchieved { get; set; }
    }
}
