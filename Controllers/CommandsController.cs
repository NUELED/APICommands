using AutoMapper;
using Commands.data;
using Commands.data.Repository;
using Commands.DTOs;
using Commands.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commands.controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
         // private readonly CommandsRepo _Repo = new CommandsRepo();
         private readonly ICommandsRepo _Repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandsRepo Repo, IMapper mapper)
          {
             _Repo = Repo;
             _mapper = mapper;
          }  
  

         //Get api/Commands
          [HttpGet]
          [ProducesResponseType(StatusCodes.Status200OK)]
         public ActionResult <IEnumerable<CommandDTO>> GetAllCommands()
         {
             var commanditems = _Repo.GetAllCommands();
             return Ok(_mapper.Map<IEnumerable<CommandDTO>>(commanditems));
         }


         // GET api/Command/id
        [HttpGet("{id}", Name="GetCommandById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         public ActionResult <CommandDTO> GetCommandById(int id)
         {
              var commanditem = _Repo.GetCommandById(id);

              if(commanditem != null )
              {
                   return Ok(_mapper.Map<CommandDTO>(commanditem));
              }
              return NotFound();
             
         }


         //Post api/Command
         [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
           public ActionResult <CommandDTOCreate> CreateCommand(CommandDTOCreate commandDTOCreate)
           {
                 var commandModel = _mapper.Map<Command>(commandDTOCreate);
                  _Repo.CreateCommand(commandModel);
                  _Repo.SaveChanges();

                  var commandDTO = _mapper.Map<CommandDTO>(commandModel);
                  return CreatedAtRoute(nameof(GetCommandById), new {id = commandDTO.id}, commandDTO);
                 // return Ok(commandDTO);
           }


           // Put api/Command/{id}
          [HttpPut("{id}")]
           public ActionResult UpdateCommand(int id, CommandDTOUpdate commandDTOUpdate)
           {
                var commandModelFromRepo = _Repo.GetCommandById(id);
                
                if(commandModelFromRepo == null)
                {
                    return NotFound();
                }
                _mapper.Map(commandDTOUpdate,commandModelFromRepo);
                _Repo.UpdateCommand(commandModelFromRepo);
                _Repo.SaveChanges();

                return NoContent();
           }

           // Patch api/Command/{id}
           [HttpPatch("{id}")]
           public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandDTOUpdate> patchDoc)
           {
                var commandModelFromRepo = _Repo.GetCommandById(id);
                
                if(commandModelFromRepo == null)
                {
                    return NotFound();
                }

                var commandToPatch = _mapper.Map<CommandDTOUpdate>(commandModelFromRepo);
                patchDoc.ApplyTo(commandToPatch, ModelState);

                if(!TryValidateModel(commandToPatch)) 
                {
                    return ValidationProblem(ModelState);
                } 

                  _mapper.Map( commandToPatch, commandModelFromRepo);
                   _Repo.UpdateCommand(commandModelFromRepo);
                   _Repo.SaveChanges();

                   return NoContent();
           }

           // Delete api/Command/{id}
           [HttpDelete("{id}")]
           public ActionResult DeleteCommand(int id)
           {
              var commandModelFromRepo = _Repo.GetCommandById(id);
                
                if(commandModelFromRepo == null)
                {
                    return NotFound();
                }
                _Repo.DeleteCommand(commandModelFromRepo);
                _Repo.SaveChanges();

                return NoContent();
           }

    }
    
}