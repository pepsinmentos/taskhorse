using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Repositories
{
    public interface IAuthenticationRepository
    {
        void Create(SignUp signUp);
        void SaveToken(string token, int expiresInSeconds);
        bool IsValidUser(AuthenticationRequest auth);
        bool IsValidToken(string token);
    }
}
