using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RallyHolder.API.Model;
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
        private readonly IMapper _mapper;
        private readonly IPilotRepositorie _pilotRepositorie;
        public PilotController(IPilotRepositorie pilotRepositorie, IMapper mapper)
        {
            _pilotRepositorie = pilotRepositorie;
            _mapper = mapper;
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
                //_logger.Info(ex.ToString());
                return StatusCode(500, "Ocorreu um erro interno no sistema!");
            }
        }

        [HttpPost]
        public IActionResult PilotAdd([FromBody] PilotModel pilotModel)
        {
            try
            {
                var pilot = _mapper.Map<Pilot>(pilotModel);

                if (_pilotRepositorie.Exist(pilot.Id))
                    return StatusCode(409, "Pilot Already Exists");

                _pilotRepositorie.Add(pilot);

                var pilotModelReturn = _mapper.Map<PilotModel>(pilot);
                return CreatedAtRoute("Get", new { id = pilot.Id }, pilotModelReturn);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString());
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
                //_logger.Info(ex.ToString());
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

        [HttpOptions]
        public IActionResult OperationsListAllowed()
        {
            Response.Headers.Add("Allowed", "GET, POST, PUT, DELETE, PATCH, OPTIONS");
            return Ok();
        }
    }
}
