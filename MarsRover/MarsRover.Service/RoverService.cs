using System;
using MarsRover.Domain.Common;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Exceptions;
using MarsRover.Domain.Interfaces;

namespace MarsRover.Service
{
    public class RoverService : BaseService, IRoverService
    {
        public object CalculateRoverMovement(Rover rover)
        {
            if (rover == null)
                throw new ArgumentNullException();
            return Move(rover);
        }

     

        public void DrawPlateau(Plateau plateau)
        {
            if (plateau.Width == 0 || plateau.Height == 0)
            {
                throw new CannotCreateAreaException();
            }
        }

        public Rover SetRoverOnPlateau(Plateau plateau, DeploymentPoint deploymentPoint)
        {
            CheckDeploymentPointIsValid(plateau, deploymentPoint);
            CheckDirectionIsValid(deploymentPoint.Direction);
            return new Rover() { DeploymentPoint = deploymentPoint, Plateau = plateau };
        }


        #region |   PRIVATE METHODS    |


        /// <summary>
        /// This method check direction 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private void CheckDirectionIsValid(Direction direction)
        {
            object result;
            Enum.TryParse(typeof(Direction), direction.ToString(), out result);
            if (result == null)
                throw new InvalidDirectionException();

        }

        /// <summary>
        /// Check between plateau to deployment point
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="deploymentPoint"></param>
        /// <returns></returns>
        private void CheckDeploymentPointIsValid(Plateau plateau, DeploymentPoint deploymentPoint)
        {
            if (plateau.Width < deploymentPoint.X || plateau.Height < deploymentPoint.Y || deploymentPoint.X < 0 || deploymentPoint.Y < 0)
                throw new OutOfBoundsFromPlateauException();

        }
        private Rover Move(Rover rover)
        {
            foreach (var movingDirection in rover.Movement.MovementList)
            {
                switch (movingDirection)
                {
                    case MovingAbility.L:
                        TurnLeft(rover);
                        break;
                    case MovingAbility.R:
                        TurnRight(rover);
                        break;
                    case MovingAbility.M:
                        GoStraight(rover);
                        break;
                    default:
                        throw new InvalidMovingAbilityParamException();
                }
            }

            return rover;
        }

        private void GoStraight(Rover rover)
        {
            switch (rover.DeploymentPoint.Direction)
            {
                case Direction.N:
                    if (rover.DeploymentPoint.Y + 1 <= rover.Plateau.Height)
                        rover.DeploymentPoint.Y += 1;
                    break;

                case Direction.E:
                    if (rover.DeploymentPoint.X + 1 <= rover.Plateau.Width)
                        rover.DeploymentPoint.X += 1;
                    break;

                case Direction.S:
                    if (rover.DeploymentPoint.Y - 1 <= rover.Plateau.Height)
                        rover.DeploymentPoint.Y -= 1;
                    break;

                case Direction.W:
                    if (rover.DeploymentPoint.X - 1 <= rover.Plateau.Width)
                        rover.DeploymentPoint.X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnRight(Rover rover)
        {
            switch (rover.DeploymentPoint.Direction)
            {
                case Direction.N:
                    rover.DeploymentPoint.Direction = Direction.E;
                    break;

                case Direction.E:
                    rover.DeploymentPoint.Direction = Direction.S;
                    break;

                case Direction.S:
                    rover.DeploymentPoint.Direction = Direction.W;
                    break;

                case Direction.W:
                    rover.DeploymentPoint.Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft(Rover rover)
        {
            switch (rover.DeploymentPoint.Direction)
            {
                case Direction.N:
                    rover.DeploymentPoint.Direction = Direction.W;
                    break;

                case Direction.W:
                    rover.DeploymentPoint.Direction = Direction.S;
                    break;

                case Direction.S:
                    rover.DeploymentPoint.Direction = Direction.E;
                    break;

                case Direction.E:
                    rover.DeploymentPoint.Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

    }
}
