using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Services.Interfaces
{
    public interface IUserService
    {
        bool ValidateUserCredentials(string username, string password);
    }
}
