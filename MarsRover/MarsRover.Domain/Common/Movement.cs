using System.Collections.Generic;

namespace MarsRover.Domain.Common
{
    public class Movement :Base, IMovement
    {
        public List<Movement> MovementList { get; set; }
    }


}
