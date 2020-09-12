using System;
using System.Collections.Generic;
using System.Text;

namespace MaggieTrainings.Domain.Models.Requests
{
    public class TrainingResultRequest
    {
        public TrainingDisciplineRequest Discipline { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
