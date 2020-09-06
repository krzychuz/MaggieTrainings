using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MaggieTrainings.Web.DataRespository;
using MaggieTrainings.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaggieTrainings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplinesRepository disciplinesRepository;

        public DisciplinesController(IDisciplinesRepository disciplinesRepository)
        {
            this.disciplinesRepository = disciplinesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDiscipline>>> Get()
        {
            return Ok(disciplinesRepository.GetAll());
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<TrainingDiscipline>> Get(int id)
        {
            var trainingItem = disciplinesRepository.Get(id);

            if (trainingItem is null)
                return NotFound();

            return Ok(trainingItem);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrainingDiscipline trainingDiscipline)
        {
            disciplinesRepository.Add(trainingDiscipline);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TrainingDiscipline trainingDiscipline)
        {
            if (id != trainingDiscipline.Id)
            {
                return BadRequest();
            }

            var trainingItem = disciplinesRepository.Get(id);

            if (trainingItem is null)
                return NotFound();

            trainingItem.Description = trainingDiscipline.Description;

            disciplinesRepository.Update(trainingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var trainingItem = disciplinesRepository.Get(id);

            if (trainingItem == null)
                return NotFound();

            disciplinesRepository.Remove(id);

            return NoContent();
        }
    }
}
