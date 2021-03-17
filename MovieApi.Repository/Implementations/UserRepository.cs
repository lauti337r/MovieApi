using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext _context;

        public UserRepository(MovieContext context)
        {
            _context = context;
        }
        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
