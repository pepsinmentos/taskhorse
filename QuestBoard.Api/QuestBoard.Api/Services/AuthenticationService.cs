using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestBoard.Api.Models;
using QuestBoard.Api.Repositories;

namespace QuestBoard.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMemberRepository _memberRepository;
        private const int EXPIRES_IN = 86400;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IMemberRepository memberRepository)
        {
            _authenticationRepository = authenticationRepository;
            _memberRepository = memberRepository;
        }

        public void Create(SignUp signUp)
        {
            if (_memberRepository.GetByEmail(signUp.Email) == null)
                throw new Exception("Member already exists for Email: " + signUp.Email);

            _authenticationRepository.Create(signUp);
        }

        public AuthenticationResult Authenticate(AuthenticationRequest auth)
        {
            if (_authenticationRepository.IsValidUser(auth))
            {
                string token = Guid.NewGuid().ToString();
                _authenticationRepository.SaveToken(token, EXPIRES_IN);

                return new AuthenticationResult { ExpiresIn = EXPIRES_IN, Token = token, IsAuthenticated = true };
            }
            else
                return new AuthenticationResult { IsAuthenticated = false };
        }

        public bool IsTokenValid(string token)
        {
            return _authenticationRepository.IsValidToken(token);
        }
    }
}