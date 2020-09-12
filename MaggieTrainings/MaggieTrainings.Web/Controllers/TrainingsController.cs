using AutoMapper;
using MaggieTrainings.Domain.Models.Data;
using MaggieTrainings.Domain.Models.Requests;
using MaggieTrainings.Web.TrainingRest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaggieTrainings.Web.Controllers
{
    [Route("api/[controller]")]
    public class TrainingsController : Controller
    {
        private readonly ITrainingHandler _trainingHandler;
        private readonly IMapper _mapper;

        public TrainingsController(ITrainingHandler maggieTrainingRestClient,
            IMapper mapper)
        {
            _trainingHandler = maggieTrainingRestClient;
            _mapper = mapper;
        }

        [HttpGet("dashboardData")]
        public IActionResult GetDashboardData()
        {
            DashboardData dashboardData = _trainingHandler.GetDashboardData();
            var dashboardDataResponse = _mapper.Map<DashboardDataResponse>(dashboardData);
            return Ok(dashboardDataResponse);
        }

        [HttpPost]
        public IActionResult AddTraining([FromBody]TrainingRequest trainingRequest)
        {
            var training = _mapper.Map<Training>(trainingRequest);
            _trainingHandler.AddTraining(training);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(int id)
        {
            var training = _trainingHandler.GetTraining(id);

            if (training == null)
                return NotFound();

            _trainingHandler.DeleteTraining(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTraining(int id, [FromForm]TrainingRequest trainingRequest)
        {
            if (id != trainingRequest.Id)
                return BadRequest();

            var training = _mapper.Map<Training>(trainingRequest);
            _trainingHandler.EditTraining(id, training);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IList<Training>> GetAllTrainings()
        {
            IList<Training> allTrainings = _trainingHandler.GetAllTrainings();
            return Ok(allTrainings);
        }
    }
}
