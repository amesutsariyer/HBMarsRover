using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public class InvalidDirectionException : BaseException
    {
        public InvalidDirectionException()
        {

        }

        public InvalidDirectionException(string message)
   : base(String.Format("Invalid Direction.Please Check your requested model", message))
        {

        }
    }
}
