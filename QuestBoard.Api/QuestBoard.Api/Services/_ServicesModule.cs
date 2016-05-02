using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace QuestBoard.Api.Services
{
    public class _ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BoardService>().As<IBoardService>().SingleInstance();
            builder.RegisterType<QuestService>().As<IQuestService>().SingleInstance();
            builder.RegisterType<MemberService>().As<IMemberService>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            base.Load(builder);
        }
    }
}