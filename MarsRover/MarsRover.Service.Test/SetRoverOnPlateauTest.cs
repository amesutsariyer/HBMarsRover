using MarsRover.Domain.Common;
using System;
using FluentAssertions;
using Xunit;
using MarsRover.Domain.Exceptions;
using MarsRover.Domain.Enum;

namespace MarsRover.Service.Test
{
    public class SetRoverOnPlateauTest
    {
        private readonly RoverService _roverService;
        public SetRoverOnPlateauTest()
        {
            _roverService = new RoverService();
        }
        [Theory]
        [InlineData("1 1 N")]
        [InlineData("4 2 S")]
        [InlineData("8 6 W")]
        public void SetRoverOnPlateau_CorrectParams(string deploymentParameter)
        {
            // Arrange
            var plataue = new Plateau(8, 6);

            var deploymentParameterSplit = deploymentParameter.Split(' ');
            var expectedX = int.Parse(deploymentParameterSplit[0]);
            var expectedY = int.Parse(deploymentParameterSplit[1]);
            var expectedDirection = deploymentParameterSplit[2];

            // Act
            var rover = _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(expectedDirection)
            {
                X = expectedX,
                Y = expectedY
            });

            // Assert
            rover.DeploymentPoint.X.Should().Be(expectedX);
            rover.DeploymentPoint.Y.Should().Be(expectedY);
            rover.DeploymentPoint.Direction.Should().Be(Enum.Parse<Direction>(expectedDirection));
        }

        [Theory]
        [InlineData("5 3 N")]
        [InlineData("10 4 S")]
        [InlineData("2 5 S")]
        [InlineData("1 5 S")]
        public void SetRoverOnPlateau_OutOfBoundsFromPlateauException_WhenHigherPointDirectionParams(string deploymentParameter)
        {
            // Arrange
            var plataue = new Plateau(2, 4);
            var deploymentParameterSplit = deploymentParameter.Split(' ');
            var expectedX = int.Parse(deploymentParameterSplit[0]);
            var expectedY = int.Parse(deploymentParameterSplit[1]);
            var expectedDirection = deploymentParameterSplit[2];

            // Act

            var action = new Action(() => _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(expectedDirection)
            {
                X = expectedX,
                Y = expectedY
            }));

            // Assert
            action.Should().Throw<OutOfBoundsFromPlateauException>();
        }

        [Theory]
        [InlineData("5 3 Q")]
        [InlineData("10 4 B")]
        [InlineData("2 5 Y")]
        [InlineData("1 5 P")]
        public void SetRoverOnPlateau_InvalidDirectionException_WhenDirectionIsInvalid(string deploymentParameter)
        {
            // Arrange
            var plataue = new Plateau(10, 10);
            var deploymentParameterSplit = deploymentParameter.Split(' ');
            var expectedX = int.Parse(deploymentParameterSplit[0]);
            var expectedY = int.Parse(deploymentParameterSplit[1]);
            var expectedDirection = deploymentParameterSplit[2];

            // Act
            var action = new Action(() => _roverService.SetRoverOnPlateau(plataue, new DeploymentPoint(expectedDirection)
            {
                X = expectedX,
                Y = expectedY
            }));

            // Assert
            action.Should().Throw<InvalidDirectionException>();
        }

    }
}
