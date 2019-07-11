using MarsRover.Domain.Enum;
using MarsRover.Domain.Exceptions;
using System;

namespace MarsRover.Domain.Common
{
    public class DeploymentPoint : Base, IDeploymentPoint
    {
        public DeploymentPoint(string navigatedDirection)
        {
            NavigatedDirection = navigatedDirection;
            SetDirection(NavigatedDirection);
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public string NavigatedDirection { get; private set; }

        public Direction SetDirection(string navigatedDirection)
        {
            object result;
            System.Enum.TryParse(typeof(Direction), navigatedDirection, out result);
            if (result == null)
                throw new InvalidDirectionException();

            return Direction = System.Enum.Parse<Direction>(Convert.ToString(result));
        }
    }
}
