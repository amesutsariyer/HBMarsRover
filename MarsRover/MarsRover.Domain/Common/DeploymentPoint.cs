using MarsRover.Domain.Enum;

namespace MarsRover.Domain.Common
{
    public class DeploymentPoint : Base,IDeploymentPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

    }
}
