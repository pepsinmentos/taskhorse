using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class TokenResult : ApiResult
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}