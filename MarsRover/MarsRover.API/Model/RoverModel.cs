using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.API.Model
{
    public class RoverModel
    {
        public DeploymentPointModel  DeploymentPoint { get; set; }
        public string Movement { get; set; }
    }
}
