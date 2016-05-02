using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Autofac;
using MongoDB.Driver;

namespace QuestBoard.Api.Repositories
{
    public class _RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BoardRepository>().As<IBoardRepository>();
            builder.RegisterType<QuestRepository>().As<IQuestRepository>();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>();
            builder.RegisterType<AuthenticationRepository>().As<IAuthenticationRepository>();

            builder.Register((c) => new MongoClient(WebConfigurationManager.AppSettings["MongoConnectionString"])).As<MongoClient>().SingleInstance();

            base.Load(builder);
        }
    }
}