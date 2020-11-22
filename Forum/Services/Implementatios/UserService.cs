using Forum.Models;
using Forum.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Forum.Constants;
using Forum.Exceptions;

namespace Forum.Services.Implementatios
{

    public class UserService : AbstractCrudService<int, User>, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IProfileRepository profileRepository;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository)
              : base(userRepository)
        {
            this.userRepository = userRepository;
            this.profileRepository = profileRepository;
        }

        public User CreateUser(string username, string email, string password)
        {
            
            Profile profile = new Profile(name: username, imagePath: ApplicationConstants.DEFAULT_IMAGE_PATH);
            User user = new User(username, email, password, profile);
            profile.User = user;
            return userRepository.Create(user);


        }

        public User LogIn(string username, string password)
        {
            User user = userRepository.FindByUsername(username);
            if (user != null && user.Password.Equals(password))
            {
                return user;
            } 
            else
            {
                throw new UserNotFoundException("User with credentials not found");
            }
        }

        public User GetByUsername(string username)
        {
            User searchResult = userRepository.FindByUsername(username);
            return searchResult != null ? searchResult : throw new UserNotFoundException("User with username " + username +" not found");
        }
    }
}
