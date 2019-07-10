using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarsRover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : BaseController
    {
        private readonly ILogger<RoverController> _logger;
        private readonly IRoverService _roverService;
        public RoverController(ILogger<RoverController> logger, IRoverService roverService) : base(logger)
        {
            _logger = logger;
            _roverService = roverService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("test");
      
            return new string[] { "value1", "value2" };
        }

      
    }
}
