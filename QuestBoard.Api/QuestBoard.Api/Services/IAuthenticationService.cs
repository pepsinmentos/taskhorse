using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Services
{
    public interface IAuthenticationService
    {
        void Create(SignUp signUp);
        AuthenticationResult Authenticate(Authentication auth);
    }
}
