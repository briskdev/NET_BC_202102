using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLogic
{
    public class LogicException : Exception
    {
        public LogicException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
