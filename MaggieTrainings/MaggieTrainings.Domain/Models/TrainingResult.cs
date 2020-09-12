using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Domain.Models
{
    public class TrainingResult
    {
        public TrainingDiscipline Discipline { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
