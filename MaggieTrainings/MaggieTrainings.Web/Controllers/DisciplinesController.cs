using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaggieTrainings.Web.DataRespository.Generics;
using Microsoft.AspNetCore.Mvc;
using MaggieTrainings.Domain.Models.Data;
using MaggieTrainings.Domain.Models.Requests;
using MaggieTrainings.Domain.Models.Responses;
using AutoMapper;

namespace MaggieTrainings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly IGenericRepository<TrainingDiscipline> _disciplinesRepository;
        private readonly IMapper _mapper;

        public DisciplinesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _disciplinesRepository = unitOfWork.Repository<TrainingDiscipline>();
            _mapper = mapper;        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainingDisciplineResponse>> GetAll()
        {
            return Ok(_disciplinesRepository.GetAll());
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TrainingDisciplineResponse> Get(int id)
        {
            var trainingItem = _disciplinesRepository.GetById(id);

            if (trainingItem is null)
                return NotFound();

            return Ok(trainingItem);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TrainingDisciplineRequest trainingDisciplineRequest)
        {
            var trainingDiscipline = _mapper.Map<TrainingDiscipline>(trainingDisciplineRequest);
            _disciplinesRepository.Insert(trainingDiscipline);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TrainingDisciplineRequest trainingDisciplineRequest)
        {
            var trainingDiscipline = _mapper.Map<TrainingDiscipline>(trainingDisciplineRequest);

            if (id != trainingDiscipline.Id)
                return BadRequest();

            var trainingItem = _disciplinesRepository.GetById(id);

            if (trainingItem is null)
                return NotFound();

            trainingItem.Description = trainingDiscipline.Description;

            _disciplinesRepository.Edit(trainingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var trainingItem = _disciplinesRepository.GetById(id);

            if (trainingItem == null)
                return NotFound();

            _disciplinesRepository.Delete(id);

            return NoContent();
        }
    }
}
