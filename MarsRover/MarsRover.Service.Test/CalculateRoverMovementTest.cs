using MarsRover.Domain.Common;
using System;
using FluentAssertions;
using Xunit;
using MarsRover.Domain.Exceptions;
using MarsRover.Domain.Enum;
using System.Linq;

namespace MarsRover.Service.Test
{
    public class CalculateRoverMovement
    {
        private readonly RoverService _roverService;
        public CalculateRoverMovement()
        {
            _roverService = new RoverService();
        }
        [Theory]
        [InlineData("MM")]
        [InlineData("MMLR")]
        [InlineData("LLLLMM")]
        public void CalculateRoverMovement_IsAcceptableMovementList(string calculationCommand)
        {
            // Arrange
            var plataue = new Plateau(5, 5);
            //Act
            var rover = _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(Direction.N.ToString())
            {
                X = 3,
                Y = 3
            });
            var movements = calculationCommand
                      .ToCharArray()
                      .Select(x => Enum.Parse<MovingAbility>(x.ToString()))
                      .ToList();

            rover.Movement.MovementList = movements;

            //Assert
            rover.Plateau.Should().NotBeNull();
            rover.Movement.MovementList.Should().NotBeNull();
            rover.DeploymentPoint.X.Should().Be(3);
            rover.DeploymentPoint.Y.Should().Be(3);
        }


        [Theory]
        [InlineData("LMLMLMLMM")]

        public void CalculateRoverMovement_TaskInput1TestIsSuccess(string calculationCommand)
        {
            // Arrange
            var plataue = new Plateau(5, 5);
            //Act
            var rover = _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(Direction.N.ToString())
            {
                X = 1,
                Y = 2
            });
            var movements = calculationCommand
                      .ToCharArray()
                  .Select(x => Enum.Parse<MovingAbility>(x.ToString()))
                      .ToList();

            rover.Movement.MovementList = movements;
            _roverService.CalculateRoverMovement(rover);

            //Assert
            rover.Plateau.Should().NotBeNull();
            rover.Movement.MovementList.Should().NotBeNull();
            rover.DeploymentPoint.X.Should().Be(1);
            rover.DeploymentPoint.Y.Should().Be(3);
            rover.DeploymentPoint.Direction.Should().Be(Direction.N);
        }

        [Theory]
        [InlineData("MMRMMRMRRM")]

        public void CalculateRoverMovement_TaskInput2TestIsSuccess(string calculationCommand)
        {
            // Arrange
            var plataue = new Plateau(5, 5);
            //Act
            var rover = _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(Direction.E.ToString())
            {
                X = 3,
                Y = 3
            });
            var movements = calculationCommand
                      .ToCharArray()
                  .Select(x => Enum.Parse<MovingAbility>(x.ToString()))
                      .ToList();

            rover.Movement.MovementList = movements;
            _roverService.CalculateRoverMovement(rover);

            //Assert
            rover.Plateau.Should().NotBeNull();
            rover.Movement.MovementList.Should().NotBeNull();
            rover.DeploymentPoint.X.Should().Be(5);
            rover.DeploymentPoint.Y.Should().Be(1);
            rover.DeploymentPoint.Direction.Should().Be(Direction.E);
        }


        [Theory]
        [InlineData("LMRMMMLLRMLMLLRR")]

        public void CalculateRoverMovement_TaskInput3ComplicatedTestIsSuccess(string calculationCommand)
        {
            // Arrange
            var plataue = new Plateau(10, 10);
            //Act
            var rover = _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(Direction.E.ToString())
            {
                X = 3,
                Y = 3
            });
            var movements = calculationCommand
                      .ToCharArray()
                  .Select(x => Enum.Parse<MovingAbility>(x.ToString()))
                      .ToList();

            rover.Movement.MovementList = movements;
            var result = _roverService.CalculateRoverMovement(rover);

            //Assert
            rover.Plateau.Should().NotBeNull();
            rover.Movement.MovementList.Should().NotBeNull();
            rover.DeploymentPoint.X.Should().Be(5);
            rover.DeploymentPoint.Y.Should().Be(5);
            rover.DeploymentPoint.Direction.Should().Be(Direction.W);
        }
    }
}
