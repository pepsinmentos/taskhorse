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
        private readonly IAuthenticationRepository _signUpRepository;
        private readonly IMemberRepository _memberRepository;

        public AuthenticationService(IAuthenticationRepository signUpRepository, IMemberRepository memberRepository)
        {
            _signUpRepository = signUpRepository;
            _memberRepository = memberRepository;
        }

        public void Create(SignUp signUp)
        {
            if (_memberRepository.GetByEmail(signUp.Email) == null)
                throw new Exception("Member already exists for Email: " + signUp.Email);

            _signUpRepository.Create(signUp);
        }

        public AuthenticationResult Authenticate(Authentication auth)
        {
            throw new NotImplementedException();
        }
    }
}