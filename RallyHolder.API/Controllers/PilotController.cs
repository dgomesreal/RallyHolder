using Microsoft.AspNetCore.Mvc;
using RallyHolder.Domain.Entities;
using RallyHolder.Domain.Interfaces;
using RallyHolder.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyHolder.API.Controllers
{
    [ApiController]
    [Route("api/pilots")]
    public class PilotController : ControllerBase
    {
        IPilotRepositorie _pilotRepositorie;
        public PilotController(IPilotRepositorie pilotRepositorie)
        {
            _pilotRepositorie = pilotRepositorie;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _pilotRepositorie.GetAll();
                if (!list.Any())
                    return NotFound();

                return Ok(list);
            }
            catch(Exception ex)
            {
                //return BadRequest(ex.ToString());
                //_logger.Info(ex.ToString());
                //return BadRequest("Occorreu um erro interno");
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
            //return Ok(_pilotRepositorie.GetAll());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var pilot = _pilotRepositorie.Get(id);
                if (pilot == null)
                    return NotFound();
                return Ok(pilot);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
        }

        [HttpPost]
        public IActionResult PilotAdd([FromBody]Pilot pilot)
        {
            try
            {
                if (_pilotRepositorie.Exist(pilot.Id))
                    return StatusCode(409, "Pilot Already Exists");

                _pilotRepositorie.Add(pilot);
                return CreatedAtRoute("Get", new { id = pilot.Id }, pilot);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
            
        }

        [HttpPut]
        public IActionResult PilotUpdate([FromBody]Pilot pilot)
        {
            try
            {
                if (!_pilotRepositorie.Exist(pilot.Id))
                    return NotFound();
                _pilotRepositorie.Update(pilot);
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }

        }

        [HttpPatch]
        public IActionResult PilotPartialUpdate([FromBody] Pilot pilot)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult PilotDelete(int id)
        {
            try
            {
                var pilot = _pilotRepositorie.Get(id);
                if (pilot == null)
                    return NotFound();
                _pilotRepositorie.Delete(pilot);
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
            
        }
    }
}
