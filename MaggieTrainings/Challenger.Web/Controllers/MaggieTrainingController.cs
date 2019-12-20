using Challenger.Web.Models;
using Challenger.Web.TrainingRest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Web.Controllers
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
            MaggieTrainings maggiTrainings = await maggieTrainingRestClient.GetTrainingData();
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
