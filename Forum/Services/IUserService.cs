﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface IUserService : ICrudService<int, User>
    {
        public User CreateUser(string username, string email, string password);
        public User GetByUsername(string username);
        User LogIn(string username, string password);
        public void Feature(string username, Topic topic);
        public void Like(string username, Message message);
        public void UpdateProfile(Profile profile);
        public void ChangeUsername(string oldUsername, string newUsername);
    }
}
