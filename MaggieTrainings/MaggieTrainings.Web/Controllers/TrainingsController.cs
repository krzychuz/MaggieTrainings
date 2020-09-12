using MaggieTrainings.Web.DataRespository;
using MaggieTrainings.Domain.Models;
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
    [Route("api/[controller]")]
    public class TrainingsController : Controller
    {
        private readonly ITrainingHandler maggieTrainingRestClient;

        public TrainingsController(ITrainingHandler maggieTrainingRestClient)
        {
            this.maggieTrainingRestClient = maggieTrainingRestClient;
        }

        [HttpGet("dashboardData")]
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

        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(int id)
        {
            maggieTrainingRestClient.DeleteTraining(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTraining([FromForm]TrainingResult trainingResult, int id)
        {
            maggieTrainingRestClient.EditTraining(id, trainingResult);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IList<Training>> GetAllTrainings()
        {
            IList<Training> allTrainings = maggieTrainingRestClient.GetAllTrainings();
            return Ok(allTrainings);
        }
    }
}
