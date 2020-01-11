using MaggieTrainings.Web.Models;
using MaggieTrainings.Web.TrainingRest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            DashboardData dashboardData = await maggieTrainingRestClient.GetDashboardData();
            return Ok(dashboardData);
        }

        [HttpPost]
        public async Task<IActionResult> AddTraining(TrainingResult trainingResult)
        {
            await maggieTrainingRestClient.AddTraining(trainingResult);
            return CreatedAtAction(nameof(TrainingResult), trainingResult);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Training>>> GetAllTrainings()
        {
            IList<Training> allTrainings = await maggieTrainingRestClient.GetAllTrainings();
            return Ok(allTrainings);
        }

        [HttpPatch]
        public async Task<IActionResult> ClearTrainingDatabase()
        {
            await maggieTrainingRestClient.ClearTrainingDatabase();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IList<TrainingDiscipline>>> GetDisciplines()
        {
            var disciplines = await maggieTrainingRestClient.GetDisciplines();
            return Ok(disciplines);
        }
    }
}
