using MarsRover.Domain.Common;
using System;
using FluentAssertions;
using Xunit;
using MarsRover.Domain.Exceptions;

namespace MarsRover.Service.Test
{
    public class DrawPlateauTest
    {
        private readonly RoverService _roverService;
        public DrawPlateauTest()
        {
            _roverService = new RoverService();
        }

        [Theory]
        [InlineData("5 5")]
        [InlineData("2 2")]
        [InlineData("10 3")]
        [InlineData("5 7")]
        public void DrawPlateauTest_CorrectParams(string plataeuParameter)
        {
            // Arrange
            var plataeuParameterSplit = plataeuParameter.Split(' ');
            var width = int.Parse(plataeuParameterSplit[0]);
            var height = int.Parse(plataeuParameterSplit[1]);

            // Act
            var plataeu = new Plateau(width, height);

            //Assert
            Assert.Equal(plataeu.Width, width);
            Assert.Equal(plataeu.Height, height);
        }

        [Theory]
        [InlineData("0 5")]
        [InlineData("0 0")]
        [InlineData("10 0")]
        [InlineData("5 0")]

        public void DrawPlateau_OutOfRangeException_WhenPointsIsNull(string plataeuParameter)
        {
            // Arrange
            var plataeuParameterSplit = plataeuParameter.Split(' ');
            var width = int.Parse(plataeuParameterSplit[0]);
            var height = int.Parse(plataeuParameterSplit[1]);

            // Act
            var plataeu = new Plateau(width, height);
            var action = new Action(() => _roverService.DrawPlateau(plataeu));

            // Assert
            action.Should().Throw<CannotCreateAreaException>();

        }
    }
}
