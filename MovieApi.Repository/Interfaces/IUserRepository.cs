using System;
using System.Collections.Generic;
using System.Text;
using MovieApi.Models;

namespace MovieApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
    }
}
