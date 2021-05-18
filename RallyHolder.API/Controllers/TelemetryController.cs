using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RallyHolder.API.Model;
using RallyHolder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RallyHolder.API.Controllers
{
    [ApiController]
    [Route("api/team/{teamId}/telemetry")]
    public class TelemetryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITelemetryRepositorie _telemetry;
        private readonly ITeamRepositorie _teamRepositorie;
        private readonly ILogger<TelemetryController> _logger;

        public TelemetryController(IMapper mapper, ITelemetryRepositorie telemetry, ILogger<TelemetryController> logger, ITeamRepositorie teamRepositorie)
        {
            _mapper = mapper;
            _telemetry = telemetry;
            _logger = logger;
            _teamRepositorie = teamRepositorie;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TelemetryModel>> Get(int teamId)
        {
            try
            {
                _logger.LogInformation($"Pilot ID{teamId} Checking if it Exists");
                if (!_teamRepositorie.Exist(teamId)){ 
                    _logger.LogWarning($"ID{teamId} Do Not Exist");
                    return NotFound();
                }

                _logger.LogInformation($"Getting Everyone was a success");
                var datasTelemetry = _telemetry.GetAllPerTeam(teamId);

                if (!datasTelemetry.Any())
                {
                    _logger.LogInformation("Not Found Datas Telemetry");
                    return NotFound("Not Found Datas Telemetry");
                }

                var datasModel = _mapper.Map<IEnumerable<TelemetryModel>>(datasTelemetry);

                return Ok(datasModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "TeamId do not Exists");
            }
            
        }
    }
}
