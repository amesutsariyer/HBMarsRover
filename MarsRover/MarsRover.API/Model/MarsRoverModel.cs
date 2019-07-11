using MarsRover.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.API.Model
{
    public class MarsRoverModel
    {
        public Plateau Plateau{ get; set; }
        public List<RoverModel> Rovers { get; set; }
    }
}
