using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Exceptions
{
    public enum ErrorCode
    {
        MESSAGE_NOT_FOUND,
        TOPIC_NOT_FOUND,
        USER_NOT_FOUND,
        PROFILE_NOT_FOUND,
        USER_IS_BANNED,
        ACCOUNT_NOT_VERIFIED,
        INVALID_VERIFICATION_STRING,
        INVALID_CREDENTIALS
    }
}
