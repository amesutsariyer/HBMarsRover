using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Exceptions
{
    public class InvalidMovingAbilityParamException : BaseException
    {
        public InvalidMovingAbilityParamException()
        {

        }

        public InvalidMovingAbilityParamException(string message)
   : base(String.Format("Invalid Moving Key For Rover", message))
        {

        }
    }
}
