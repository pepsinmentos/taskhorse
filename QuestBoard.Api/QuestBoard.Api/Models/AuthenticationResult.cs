using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}