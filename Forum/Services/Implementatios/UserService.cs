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
        private readonly IMailService mailService;

        public UserService(IUserRepository userRepository, 
                           IProfileRepository profileRepository, 
                           IRoleRepository roleRepository,
                           IMailService mailService)
              : base(userRepository)
        {
            this.userRepository = userRepository;
            this.profileRepository = profileRepository;
            this.roleRepository = roleRepository;
            this.mailService = mailService;
        }

        public User CreateUser(string username, string email, string password)
        {
            
            Profile profile = new Profile(name: username, imagePath: ApplicationConstants.DEFAULT_IMAGE_PATH);
            User user = new User(username, email, password, profile);
            user.VerificationString = UtilsService.GenerateRandomVerificationString();
            user.Roles = new List<Role> { roleRepository.FindByName(ApplicationConstants.USER_ROLE_NAME) };
            profile.User = user;
            
            user = userRepository.Create(user);
            mailService.SendVerificationMail(user.Email, GenerateVerificationUrl(user.UserId, user.VerificationString));
            return user;

        }

        public User LogIn(string username, string password)
        {
            User user = userRepository.FindByUsername(username);
            if (user != null && user.Password.Equals(password))
            {
                if (user.Banned)
                {
                    throw new BusinessException(ErrorCode.USER_IS_BANNED);
                } else if (!user.Verified)
                {
                    throw new BusinessException(ErrorCode.ACCOUNT_NOT_VERIFIED);
                }
                return user;
            } 
            else
            {
                throw new BusinessException(ErrorCode.INVALID_CREDENTIALS);
            }
        }

        public User GetByUsername(string username)
        {
            User searchResult = userRepository.FindByUsername(username);
            return searchResult != null ? searchResult : throw new BusinessException(ErrorCode.USER_NOT_FOUND);
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

        public User Verify(int userId, string verificationString)
        {
            User user = userRepository.Read(userId);
            if (user.VerificationString == verificationString)
            {
                user.Verified = true;
                user.VerificationString = "";
                userRepository.Update(user);
                return user;
            } else
            {
                throw new BusinessException(ErrorCode.INVALID_VERIFICATION_STRING);
            }
        }

        private string GenerateVerificationUrl(int accountId, string verificationString)
        {

            return ApplicationConstants.BASE_URL + "/Account/Verify/" + accountId + "?verificationString=" + verificationString;
        }
    }
}
