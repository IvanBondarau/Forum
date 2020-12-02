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
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository, IRoleRepository roleRepository)
              : base(userRepository)
        {
            this.userRepository = userRepository;
            this.profileRepository = profileRepository;
            this.roleRepository = roleRepository;
        }

        public User CreateUser(string username, string email, string password)
        {
            
            Profile profile = new Profile(name: username, imagePath: ApplicationConstants.DEFAULT_IMAGE_PATH);
            User user = new User(username, email, password, profile);
            user.Roles = new List<Role> { roleRepository.FindByName(ApplicationConstants.USER_ROLE_NAME) };
            profile.User = user;
            return userRepository.Create(user);


        }

        public User LogIn(string username, string password)
        {
            User user = userRepository.FindByUsername(username);
            if (user != null && user.Password.Equals(password))
            {
                if (user.Banned)
                {
                    throw new BusinessException(ErrorCode.USER_IS_BANNED);
                }
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

        public void Feature(string username, Topic topic)
        {
            User user = GetByUsername(username);
            user.Featured.Add(topic);
            userRepository.Update(user);
        }

        public void Like(string username, Message message)
        {
            User user = GetByUsername(username);
            user.Likes.Add(message);
            userRepository.Update(user);
        }

        public void UpdateProfile(Profile profile)
        {
            profileRepository.Update(profile);
        }

        public void ChangeUsername(string oldUsername, string newUsername)
        {
            User user = GetByUsername(oldUsername);
            user.Username = newUsername;
            userRepository.Update(user);
        }

        public void MakeModerator(int userId)
        {
            User user = userRepository.Read(userId);
            user.Roles.Add(roleRepository.FindByName(ApplicationConstants.MODERATOR_ROLE_NAME));
            userRepository.Update(user);
        }

        public void RemoveModerator(int userId)
        {
            User user = userRepository.Read(userId);
            user.Roles.Remove(roleRepository.FindByName(ApplicationConstants.MODERATOR_ROLE_NAME));
            userRepository.Update(user);
        }

        public void Ban(int userId)
        {
            User user = userRepository.Read(userId);
            user.Banned = true;
            userRepository.Update(user);
        }

        public void Unban(int userId)
        {
            User user = userRepository.Read(userId);
            user.Banned = false;
            userRepository.Update(user);
        }
    }
}
