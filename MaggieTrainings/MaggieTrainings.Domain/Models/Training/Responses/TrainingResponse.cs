using System;
using System.Collections.Generic;
using System.Text;

namespace MaggieTrainings.Domain.Models.Responses
{
    public class TrainingResponse
    {
        public int Id { get; set; }

        public TrainingResultResponse TrainingResult { get; set; }
    }
}
