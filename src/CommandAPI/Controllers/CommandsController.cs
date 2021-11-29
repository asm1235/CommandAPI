using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController:ControllerBase
    {
        private readonly ICommandAPIRepo _respository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _respository = repository;
        }
        [HttpGet]        
        public ActionResult<IEnumerable<Command>> Get()
        {
            var commandItems = _respository.GetAllCommands();
            return Ok(commandItems);
        }
        [HttpGet("{Id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _respository.GetCommandById(id);
            if(command==null)
            return NotFound();
            else
            {
            return Ok(command);    
            }
            
        }
    }
}