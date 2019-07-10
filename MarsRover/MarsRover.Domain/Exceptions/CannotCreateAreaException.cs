using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public class CannotCreateAreaException : BaseException
    {
        public CannotCreateAreaException()
        {

        }

        public CannotCreateAreaException(string message)
   : base(String.Format("Invalid Parameters For Drawing Plataeu Area", message))
        {

        }
    }
}
