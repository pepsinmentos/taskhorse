using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using NLog;
using QuestBoard.Api.Services;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace QuestBoard.Api.Filters
{
    public class AuthenticateFilter : IAutofacActionFilter
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateFilter(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public void OnActionExecuting(HttpActionContext actionContext)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Authenticate Filter called");
            var token = actionContext.Request.Headers.Authorization;

            if (token.Scheme == "Bearer" && !_authenticationService.IsTokenValid(token.Parameter))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));

            if (token.Scheme == "Basic")
            {
                var base64EncodedBytes = System.Convert.FromBase64String(token.Parameter);
                var usernamePassword = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                if (!_authenticationService.Authenticate(new Models.AuthenticationRequest { Email = usernamePassword.Split(':')[0], Password = usernamePassword.Split(':')[1] }).IsAuthenticated)
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }

        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
        }
    }
}