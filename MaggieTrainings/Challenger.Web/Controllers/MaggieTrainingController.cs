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
        public IActionResult GetDashboardData()
        {
            DashboardData dashboardData = maggieTrainingRestClient.GetDashboardData();
            return Ok(dashboardData);
        }

        [HttpPost]
        public IActionResult AddTraining(TrainingResult trainingResult)
        {
            maggieTrainingRestClient.AddTraining(trainingResult);
            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult DeleteTraining(int id)
        {
            maggieTrainingRestClient.DeleteTraining(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IList<Training>> GetAllTrainings()
        {
            IList<Training> allTrainings = maggieTrainingRestClient.GetAllTrainings();
            return Ok(allTrainings);
        }

        [HttpPatch]
        public IActionResult ClearTrainingDatabase()
        {
            maggieTrainingRestClient.ClearTrainingDatabase();
            return Ok();
        }

        [HttpGet]
        public ActionResult<IList<TrainingDiscipline>> GetDisciplines()
        {
            var disciplines = maggieTrainingRestClient.GetDisciplines();
            return Ok(disciplines);
        }
    }
}
