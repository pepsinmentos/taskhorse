using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestBoard.Api.Exceptions;
using QuestBoard.Api.Models;
using QuestBoard.Api.Repositories;

namespace QuestBoard.Api.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public Member Create(Member model)
        {
            if (_memberRepository.GetByEmail(model.Email) != null)
                throw new MemberAlreadyExistsException("Member already exists for email: " + model.Email);

            return _memberRepository.Create(model);
        }
    }
}