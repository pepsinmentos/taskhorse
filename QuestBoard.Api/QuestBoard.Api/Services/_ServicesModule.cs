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
            builder.RegisterType<BoardService>().As<IBoardService>();
            builder.RegisterType<QuestService>().As<IQuestService>();
            base.Load(builder);
        }
    }
}