using System;
using System.Collections.Generic;
using System.Text;
using MovieApi.Models;
using MovieApi.Repository.Implementations;
using MovieApi.Repository.Interfaces;
using MovieApi.Services.Interfaces;
using MovieApi.Utils;

namespace MovieApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool ValidateUserCredentials(string username, string password)
        {
            string hashedPassword = StringUtils.Hash(password);

            User user = _userRepository.GetUser(username);

            if (user == null)
                return false;
            if (user.Password == hashedPassword)
                return true;
            return false;
        }
    }
}
