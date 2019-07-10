using System;
using MarsRover.Domain.Common;
using MarsRover.Domain.Interfaces;

namespace MarsRover.Service
{
    public class RoverService : BaseService, IRoverService
    {
        public object CalculateRoverMovement()
        {
            throw new NotImplementedException();
        }

        public void DeployRover()
        {
            throw new NotImplementedException();
        }

        public void DrawPlateau(Plataeu plataeu)
        {
            if (plataeu.Width == 0 || plataeu.Height == 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
