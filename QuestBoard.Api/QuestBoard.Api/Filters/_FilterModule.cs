using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using QuestBoard.Api.Controllers;

namespace QuestBoard.Api.Filters
{
    public class _FilterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticateFilter>().AsWebApiActionFilterFor<BoardController>().SingleInstance();
            base.Load(builder);
        }
    }
}