using System;
using System.Text;

namespace MarsRover.Domain.Common
{
    public class MarsRover : Base,IMarsRover
    {
        public Plataeu Plataeu { get; set; }
        public DeploymentPoint DeploymentPoint { get; set; }
        public Movement Movement { get; set; }
    }


}
