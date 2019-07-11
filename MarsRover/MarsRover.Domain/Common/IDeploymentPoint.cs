using MarsRover.Domain.Enum;

namespace MarsRover.Domain.Common
{
    public interface IDeploymentPoint
    {
        int X { get; set; }
        int Y { get; set; }
        string NavigatedDirection { get; }
        Direction Direction { get; }
        Direction SetDirection(string navigatedDirection);
    }


}
