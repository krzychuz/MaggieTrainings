using System;
using System.Collections.Generic;
using System.Text;

namespace MaggieTrainings.Domain.Models.Responses
{
    public class TrainingResultResponse
    {
        public TrainingDisciplineResponse Discipline { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
