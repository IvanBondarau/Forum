using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Exceptions
{


    public class ErrorHandler
    {
        public static readonly Dictionary<ErrorCode, string> ERROR_MESSAGES;

        static ErrorHandler()
        {
            ERROR_MESSAGES = new Dictionary<ErrorCode, string>
            {
                {  ErrorCode.ACCOUNT_NOT_VERIFIED, "This account has not been verified yet. Please check your email and verify your account." },
                {  ErrorCode.INVALID_VERIFICATION_STRING, "This confirmation link is incorrect." },
                {  ErrorCode.MESSAGE_NOT_FOUND, "Message not found" },
                {  ErrorCode.TOPIC_NOT_FOUND, "Topic not found" },
                {  ErrorCode.USER_NOT_FOUND, "User not found" },
                {  ErrorCode.USER_IS_BANNED, "This account has been blocked. Contact the site administration." },
            };
        }


        public ErrorHandler()
        {

        }
    }
}
