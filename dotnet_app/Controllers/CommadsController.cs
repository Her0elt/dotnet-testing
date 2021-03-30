using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dotnet_app.Models;
using dotnet_app.Data;
using dotnet_app.Dtos.Commands;
using AutoMapper;

namespace dotnet_app.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(CommandRepo repo, IMapper mapper)
        {
             _repo = repo;   
             _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Command>> getAll()
        {
            return Ok(_repo.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<CommandRead> get(int id)
        {
            var command = _repo.getById(id);
            if(command != null){
                return Ok(_mapper.Map<CommandRead>(command));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandRead> create(CommandCreate cmd)
        {
            var model = _mapper.Map<Command>(cmd);
            _repo.create(model);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public ActionResult<CommandRead> update(int id, CommadUpdate cmd)
        {
            var dbModel = _repo.getById(id);

            if( dbModel == null) return NotFound();

            _mapper.Map(cmd, dbModel);  
            _repo.update(dbModel);
            return _mapper.Map<Command, CommandRead >(dbModel);     
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