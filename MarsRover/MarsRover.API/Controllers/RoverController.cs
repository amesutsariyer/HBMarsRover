using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.API.Model;
using MarsRover.Domain.Common;
using MarsRover.Domain.Enum;
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
        [HttpPost]
        public object Post([FromBody] MarsRoverModel model)
        {
            var roverList = new List<Rover>();
            foreach (var roverItem in model.Rovers)
            {
                var plateau = _roverService.DrawPlateau(model.Plateau);
                var rover = _roverService.SetRoverOnPlateau(model.Plateau, new DeploymentPoint(roverItem.DeploymentPoint.Direction.ToString())
                {
                    X = roverItem.DeploymentPoint.X,
                    Y = roverItem.DeploymentPoint.Y
                });
                var movements = roverItem.Movement
                          .ToCharArray()
                      .Select(x => Enum.Parse<MovingAbility>(x.ToString()))
                          .ToList();

                rover.Movement.MovementList = movements;
                roverList.Add(_roverService.CalculateRoverMovement(rover, plateau));
            }
            return roverList.Select(x => new DeploymentPointModel()
            {
                X = x.DeploymentPoint.X,
                Y = x.DeploymentPoint.Y,
                Direction = x.DeploymentPoint.Direction.ToString()

            });
        }


    }
}
