using MaggieTrainings.Web.Models;
using MaggieTrainings.Web.TrainingRest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.Controllers
{
    public class MaggieTrainingController : Controller
    {
        private readonly IMaggieTrainingRestClient maggieTrainingRestClient;

        public MaggieTrainingController(IMaggieTrainingRestClient maggieTrainingRestClient)
        {
            this.maggieTrainingRestClient = maggieTrainingRestClient;
        }

        public async Task<IActionResult> GetDashboardData()
        {
            DashboardData dashboardData = await maggieTrainingRestClient.GetDashboardData();
            return Ok(dashboardData);
        }

        public async Task AddTraining()
        {
            await maggieTrainingRestClient.AddTraining();
        }

        public async Task CreateTrainingDatabase()
        {
            await maggieTrainingRestClient.CreateTrainingDatabase();
        }

        public async Task ClearTrainingDatabase()
        {
            await maggieTrainingRestClient.ClearTrainingDatabase();
        }
    }
}
