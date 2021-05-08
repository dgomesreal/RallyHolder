using Microsoft.AspNetCore.Mvc;
using RallyHolder.Domain.Entities;
using RallyHolder.Domain.Interfaces;
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
            return Ok(_pilotRepositorie.GetAll());
        }

        [HttpPost]
        public IActionResult AddPilot([FromBody]Pilot pilot)
        {
            _pilotRepositorie.Add(pilot);
            return Ok();
        }
    }
}
