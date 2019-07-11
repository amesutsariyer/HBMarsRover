using MarsRover.Domain.Common;

namespace MarsRover.Domain.Interfaces
{
    public interface IRoverService
    {
        Plateau DrawPlateau(Plateau plateau);
        Rover SetRoverOnPlateau(Plateau plateau, DeploymentPoint deploymentPoint);
        Rover CalculateRoverMovement(Rover rover, Plateau plateau);

    }
}
