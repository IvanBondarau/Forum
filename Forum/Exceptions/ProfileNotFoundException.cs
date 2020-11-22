using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Exceptions
{
    public class ProfileNotFoundException: Exception
    {
        public ProfileNotFoundException(string message)
            : base(message:message)
        {

        }
    }
}
