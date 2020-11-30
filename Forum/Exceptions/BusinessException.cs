using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Exceptions
{
    public class BusinessException: Exception
    {
        public readonly ExceptionCode Code;

        public BusinessException(ExceptionCode code)
        {
            Code = code;
        }
    }
}
