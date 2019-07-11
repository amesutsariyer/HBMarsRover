using System;
using System.Collections.Generic;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Exceptions;

namespace MarsRover.Domain.Common
{
    public class Movement : Base, IMovement
    {
        public List<Enum.MovingAbility> MovementList { get; set; }
    }


}
