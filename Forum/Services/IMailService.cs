using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface IMailService
    {
        void SendVerificationMail(string email, string verificationString);
    }
}
