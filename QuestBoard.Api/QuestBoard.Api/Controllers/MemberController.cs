using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Controllers
{
    public class MemberController : ApiController
    {
        public MemberController()
        {
            
        }

        [HttpPost]
        public ApiResult Post(SignUp signUp)
        {
            return new ApiResult();
        }

    }
}