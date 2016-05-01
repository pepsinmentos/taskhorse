using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Exceptions
{
    public class MemberAlreadyExistsException : Exception
    {
        public MemberAlreadyExistsException(string message) : base(message) { }
    }
}