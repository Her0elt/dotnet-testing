using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dotnet_app.Models;
using dotnet_app.Data;
using dotnet_app.Dtos.Person;
using AutoMapper;

namespace dotnet_app.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepo _repo;
        private readonly IMapper _mapper;

        public PersonController(PersonRepo repo, IMapper mapper)
        {
             _repo = repo;   
             _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PersonListDto>> getAll()
        {
            return Ok(_repo.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> get(int id)
        {
            var person = _repo.getById(id);
            if(person != null){
                return Ok(_mapper.Map<PersonDto>(person));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PersonDto> create(PersonCreateDto person)
        {
            var model = new Person
            {
                name = person.name,
                dad = _repo.getById(person.dadId),
                mom = _repo.getById(person.momId)
            };
            _repo.create(model);
            return Ok(_mapper.Map<PersonDto>(model));
        }
        [HttpPut("{id}")]
        public ActionResult<PersonDto> update(int id, PersonDto person)
        {
            var dbModel = _repo.getById(id);

            if( dbModel == null) return NotFound();

            _mapper.Map(person, dbModel);  
            _repo.update(dbModel);
            return Ok(_mapper.Map<PersonDto>(dbModel));     
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            var dbModel = _repo.getById(id);

            if( dbModel == null) return NotFound();

            _repo.delete(dbModel);
            return NoContent();

        }

    }
}