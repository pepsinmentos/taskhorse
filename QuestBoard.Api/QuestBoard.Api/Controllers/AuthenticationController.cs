using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using QuestBoard.Api.Exceptions;
using QuestBoard.Api.Models;
using QuestBoard.Api.Services;

namespace QuestBoard.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMemberService _memberService;

        public AuthenticationController(IAuthenticationService authenticationService, IMemberService memberService)
        {
            _authenticationService = authenticationService;
            _memberService = memberService;
        }

        [HttpPost]
        [Route("api/authentication/signup")]
        public HttpResponseMessage SignUp(SignUp signup)
        {
            try
            {
                _memberService.Create(new Member { Email = signup.Email, Password = signup.Password, Username = signup.Username, SignUpSource = signup.Source });
                HttpContext.Current.Response.StatusCode = 201;
                /* STATUS 201 Resource created */
            }
            catch (MemberAlreadyExistsException)
            {
                /* STATUS 409 Conflict - The resource already exists */
                return new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("This user already exists") };
            }

            return new HttpResponseMessage(HttpStatusCode.Created) { Content = new StringContent("User has been created") };
        }

        [HttpPost]
        public HttpResponseMessage Authenticate(AuthenticationRequest auth)
        {
            // Check that credentials match
            var authResult = _authenticationService.Authenticate(auth);
            if (authResult.IsAuthenticated)
            {
                /* SET AUTH SUCCESSFUL STATUS*/
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new TokenResult()
                    {
                        Success = true,
                        ExpiresIn = authResult.ExpiresIn,
                        Message = "Authentication successful",
                        Token = authResult.Token
                    }))
                };
            }
            else
            {
                /* SET AUTH FAILED 403
                 WWW-Authenticate: Bearer realm="example"
                 */
                HttpContext.Current.Response.AddHeader("WWW-Authenticate", "Bearer " + "QuestBoard");
                return new HttpResponseMessage(HttpStatusCode.Forbidden) { Content = new StringContent("Authentication failed") };
            }
          
        }
    }
}