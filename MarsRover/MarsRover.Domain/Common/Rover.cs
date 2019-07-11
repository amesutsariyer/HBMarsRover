using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Common
{
    public class Rover : Base, IMarsRover
    {
        public Rover()
        {
            Movement = new Movement( );
        }
        public DeploymentPoint DeploymentPoint { get; set; }
        public Movement Movement { get; set; }

    }


}
