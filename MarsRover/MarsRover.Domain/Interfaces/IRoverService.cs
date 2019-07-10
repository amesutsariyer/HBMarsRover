using MarsRover.Domain.Common;

namespace MarsRover.Domain.Interfaces
{
    public interface IRoverService
    {
        void DrawPlateau(Plataeu plataeu);
        void DeployRover();
        object CalculateRoverMovement();

    }
}
