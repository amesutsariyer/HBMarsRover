using MarsRover.Domain.Enum;

namespace MarsRover.Domain.Common
{
    public interface IDeploymentPoint
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
    }


}
