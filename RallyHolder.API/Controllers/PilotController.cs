using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RallyHolder.API.Model;
using RallyHolder.Domain.Entities;
using RallyHolder.Domain.Interfaces;
using System;

namespace RallyHolder.API.Controllers
{
    [ApiController]
    [Route("api/pilots")]
    public class PilotController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPilotRepositorie _pilotRepositorie;
        private readonly ILogger<PilotController> _logger;
        public PilotController(IPilotRepositorie pilotRepositorie, IMapper mapper, ILogger<PilotController> logger)
        {
            _pilotRepositorie = pilotRepositorie;
            _mapper = mapper;
            _logger = logger;
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        var list = _pilotRepositorie.GetAll();
        //        if (!list.Any())
        //            return NotFound();

        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        //return BadRequest(ex.ToString());
        //        //_logger.Info(ex.ToString());
        //        //return BadRequest("Occorreu um erro interno");
        //        return StatusCode(500, "Ocorreu um erro interno no sistema!");
        //    }
        //    //return Ok(_pilotRepositorie.GetAll());
        //}

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var pilot = _pilotRepositorie.Get(id);

                if (pilot == null)
                    return NotFound();

                var pilotModel = _mapper.Map<PilotModel>(pilot);

                return Ok(pilotModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
        }

        [HttpPost]
        public IActionResult PilotAdd([FromBody] PilotModel pilotModel)
        {
            try
            {
                _logger.LogInformation("Mapping Pilot Model");
                var pilot = _mapper.Map<Pilot>(pilotModel);

                _logger.LogInformation($"Pilot ID{pilot.Id} Checking if it Exists");
                if (_pilotRepositorie.Exist(pilot.Id))
                {
                    _logger.LogWarning($"Pilot ID{pilot.Id} Exists");
                    return StatusCode(409, "Pilot Already Exists");
                }

                _logger.LogInformation("Adding Pilot");
                _pilotRepositorie.Add(pilot);

                var pilotModelReturn = _mapper.Map<PilotModel>(pilot);
                return CreatedAtRoute("Get", new { id = pilot.Id }, pilotModelReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }

        }

        [HttpPut]
        public IActionResult PilotUpdate([FromBody] PilotModel pilotModel)
        {
            try
            {
                if (!_pilotRepositorie.Exist(pilotModel.Id))
                    return NotFound();

                var pilot = _mapper.Map<Pilot>(pilotModel);

                _pilotRepositorie.Update(pilot);
                return NoContent();
            }
            catch (Exception ex)
            {   
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }

        }

        [HttpPatch("{id}")]
        public IActionResult PilotPartialUpdate(int id, [FromBody] JsonPatchDocument<PilotModel> patchPilotModel)
        {
            try
            {
                if (!_pilotRepositorie.Exist(id))
                    return NotFound();

                var pilot = _pilotRepositorie.Get(id);
                var pilotModel = _mapper.Map<PilotModel>(pilot);

                patchPilotModel.ApplyTo(pilotModel);

                pilot = _mapper.Map(pilotModel, pilot);

                _pilotRepositorie.Update(pilot);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult PilotDelete(int id)
        {
            try
            {
                _logger.LogInformation($"Checking if {id} Exists");
                var pilot = _pilotRepositorie.Get(id);
                if (pilot == null) {
                    _logger.LogWarning($"{id} NOT Exists");
                    return NotFound();
                }
                _logger.LogInformation($"{id} Deleted");
                _pilotRepositorie.Delete(pilot);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }

        }

        [HttpOptions]
        public IActionResult OperationsListAllowed()
        {
            Response.Headers.Add("Allowed", "GET, POST, PUT, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
