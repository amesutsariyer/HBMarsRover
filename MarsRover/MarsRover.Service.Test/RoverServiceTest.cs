using MarsRover.Domain.Common;
using MarsRover.Domain.Interfaces;
using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Service.Test
{
    public class RoverServiceTest
    {
        private readonly RoverService _roverService;
        public RoverServiceTest()
        {
            _roverService = new RoverService();
        }
        //[Fact]
        //public object CalculateRoverMovement()
        //{
        //    throw new NotImplementedException();
        //}
        //[Fact]

        //public void DeployRover()
        //{
        //    throw new NotImplementedException();
        //}

        [Theory]
        [InlineData("5 5")]
        [InlineData("2 2")]
        [InlineData("10 3")]
        [InlineData("5 7")]

        public void DrawPlateauTest(string plataeuParameter)
        {
            // Arrange
            var plataeuParameterSplit = plataeuParameter.Split(' ');
            var width = int.Parse(plataeuParameterSplit[0]);
            var height = int.Parse(plataeuParameterSplit[1]);

            // Act
            var plataeu = new Plataeu(width, height);

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
            var plataeu = new Plataeu(width, height);

            var action = new Action(() => _roverService.DrawPlateau(plataeu));

            // Assert
            action.Should().Throw<IndexOutOfRangeException>();

        }
    }
}
