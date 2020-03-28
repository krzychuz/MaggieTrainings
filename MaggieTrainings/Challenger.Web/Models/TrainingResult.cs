using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.Models
{
    public class TrainingResult
    {
        public TrainingResult()
        {
        }

        // TODO: This SHALL NOT be string. We should send and store Id
        // While returning view we should map Id to actual discipline name
        public string DisciplineName { get; set; }

        public int TrainingDuration { get; set; }

        public string TrainingDate { get; set; }
    }
}
