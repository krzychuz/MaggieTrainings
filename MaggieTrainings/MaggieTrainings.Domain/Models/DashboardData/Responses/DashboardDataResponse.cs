using System;

namespace MaggieTrainings.Domain.Models.Data
{
    public class DashboardDataResponse
    {

        public int NumberOfTrainings { get; set; }

        public DateTime LastTraining { get; set; }

        public bool IsYearlyGoalAchieved { get; set; }
    }
}
