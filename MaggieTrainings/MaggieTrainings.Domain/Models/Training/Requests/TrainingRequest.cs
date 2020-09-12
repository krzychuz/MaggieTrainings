using System;
using System.Collections.Generic;
using System.Text;

namespace MaggieTrainings.Domain.Models.Requests
{
    public class TrainingRequest
    {
        public int Id { get; set; }

        public TrainingResultRequest TrainingResult { get; set; }
    }
}
