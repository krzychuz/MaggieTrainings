using LiteDB;

namespace MaggieTrainings.Domain.LegacyModels
{
    public class LegacyTraining
    {
        [BsonId]
        public int Id { get; set; }

        [BsonField]
        public string AddDate { get; set; }
        
        [BsonField]
        public string EditDate { get; set; }

        [BsonField]
        public LegacyTrainingResult TrainingResult { get; set; }
    }
}
