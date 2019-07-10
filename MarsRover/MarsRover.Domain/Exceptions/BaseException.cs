using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {

        public BaseException()
        {

        }

        public BaseException(string message) : base(message)
        {

        }
    }
}
