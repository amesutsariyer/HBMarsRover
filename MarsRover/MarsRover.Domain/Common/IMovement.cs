using System.Collections.Generic;

namespace MarsRover.Domain.Common
{
    public interface IMovement
    {
        List<Enum.MovingAbility> MovementList { get; set; }
    }


}
