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

        public async Task<IActionResult> GetTrainingData()
        {
            Trainings maggiTrainings = await maggieTrainingRestClient.GetTrainingData();
            return Ok(maggiTrainings);
        }

        public async Task IncreaseTrainingNumber()
        {
            await maggieTrainingRestClient.IncreaseTrainingNumber();
        }

        public async Task CreateTrainingDatabase()
        {
            await maggieTrainingRestClient.CreateTrainingDatabase();
        }
    }
}
