using LiteDB;

namespace MaggieTrainings.Web.Models
{
    public class Training
    {
        [BsonId]
        public int Id { get; set; }

        [BsonField]
        public string AddDate { get; set; }
        
        [BsonField]
        public string EditDate { get; set; }

        [BsonField]
        public TrainingResult TrainingResult { get; set; }
    }
}
