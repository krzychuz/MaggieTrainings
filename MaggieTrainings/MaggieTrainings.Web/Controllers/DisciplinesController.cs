using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaggieTrainings.Web.DataRespository.Generics;
using MaggieTrainings.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaggieTrainings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly IGenericRepository<TrainingDiscipline> disciplinesRepository;

        public DisciplinesController(IUnitOfWork unitOfWork)
        {
            this.disciplinesRepository = unitOfWork.Repository<TrainingDiscipline>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDiscipline>>> Get()
        {
            return Ok(disciplinesRepository.GetAll());
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<TrainingDiscipline>> Get(int id)
        {
            var trainingItem = disciplinesRepository.GetById(id);

            if (trainingItem is null)
                return NotFound();

            return Ok(trainingItem);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TrainingDiscipline trainingDiscipline)
        {
            disciplinesRepository.Insert(trainingDiscipline);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TrainingDiscipline trainingDiscipline)
        {
            if (id != trainingDiscipline.Id)
            {
                return BadRequest();
            }

            var trainingItem = disciplinesRepository.GetById(id);

            if (trainingItem is null)
                return NotFound();

            trainingItem.Description = trainingDiscipline.Description;

            disciplinesRepository.Edit(trainingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var trainingItem = disciplinesRepository.GetById(id);

            if (trainingItem == null)
                return NotFound();

            disciplinesRepository.Delete(id);

            return NoContent();
        }
    }
}
