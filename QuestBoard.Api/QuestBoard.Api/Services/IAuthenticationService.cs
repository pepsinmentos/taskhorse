﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResult Authenticate(AuthenticationRequest auth);
        bool IsTokenValid(string token);
    }
}
