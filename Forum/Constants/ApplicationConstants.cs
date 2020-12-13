using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Constants
{
    public class ApplicationConstants
    {
        public static readonly string BASE_URL = "https://webforum.azurewebsites.net";

        public static readonly String DEFAULT_IMAGE_PATH = "/img/avatar1.png";
        public static readonly int TOPIC_PAGE_SIZE = 10;
        public static readonly int MESSAGE_PAGE_SIZE = 5;

        public static readonly string USER_ROLE_NAME = "User";
        public static readonly string ADMIN_ROLE_NAME = "Admin";
        public static readonly string MODERATOR_ROLE_NAME = "Moderator";

    }
}
