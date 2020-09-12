using System;
using System.Collections.Generic;
using System.Text;

namespace MaggieTrainings.Domain.Models.Requests
{
    public class TrainingDisciplineRequest
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
