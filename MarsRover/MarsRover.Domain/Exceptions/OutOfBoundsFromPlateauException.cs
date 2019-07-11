using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public class OutOfBoundsFromPlateauException : BaseException
    {
        public OutOfBoundsFromPlateauException()
        {

        }

        public OutOfBoundsFromPlateauException(string message)
   : base(String.Format("Rover can't located on plateau.Deployment error.Please check deployment point", message))
        {

        }
    }
}
