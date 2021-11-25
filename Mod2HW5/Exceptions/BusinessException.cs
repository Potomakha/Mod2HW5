using System;
using System.Collections.Generic;
using System.Text;

namespace Mod2HW5.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
