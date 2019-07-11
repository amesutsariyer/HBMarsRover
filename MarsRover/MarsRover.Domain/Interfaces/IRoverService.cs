using MarsRover.Domain.Common;

namespace MarsRover.Domain.Interfaces
{
    public interface IRoverService
    {
        void DrawPlateau(Plateau plateau);
        Rover SetRoverOnPlateau(Plateau plateau, DeploymentPoint deploymentPoint);
        object CalculateRoverMovement(Rover rover);

    }
}
