using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace QuestBoard.Api.Controllers
{
    public class _ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            base.Load(builder);
        }
    }
}