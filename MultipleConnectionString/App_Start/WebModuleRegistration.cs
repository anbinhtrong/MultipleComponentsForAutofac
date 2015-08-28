using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using MultipleConnectionString.Repositories;

namespace MultipleConnectionString.App_Start
{
    public class WebModuleRegistration : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder",
                                                "Argument builder can not be null.");
            }
            //This is where you register all dependencies
            builder.RegisterType<MessageRepository>().Named<IMessageRepository>("message_repo").AsImplementedInterfaces();
            builder.RegisterType<ChineseMessageRepository>().Named<IMessageRepository>("chinese_repo").AsImplementedInterfaces();
            builder.RegisterType<VietnameseMessageRepository>()
                .Named<IMessageRepository>("vietnamese_repo")
                .AsImplementedInterfaces();
            builder.RegisterType<MessageService>()
                .Named<IMessageService>("message_service")
                .WithParameter(ResolvedParameter.ForNamed<IMessageRepository>("message_repo")).AsImplementedInterfaces();
            builder.RegisterType<ChineseMessageService>().Named<IMessageService>("chinese_service").WithParameter(ResolvedParameter.ForNamed<IMessageRepository>("chinese_repo")).AsImplementedInterfaces();
            builder.RegisterType<VietnameseMessageService>().Named<IMessageService>("vietnamese_service").WithParameter(ResolvedParameter.ForNamed<IMessageRepository>("vietnamese_repo")).AsImplementedInterfaces();
            //builder.RegisterType<ChineseMessageService>().Named<IMessageService>("chinese_service").WithParameter((p, c) => p.Name == "chinese_service", (p, c) => c.ResolveNamed<IMessageRepository>("chinese_repo")).AsImplementedInterfaces();
            //builder.RegisterType<VietnameseMessageService>().Named<IMessageService>("vietnamese_service").WithParameter((p, c) => p.Name == "vietnamese_service", (p, c) => c.ResolveNamed<IMessageRepository>("vietnamese_repo")).AsImplementedInterfaces();
            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            base.Load(builder);
        }
    }
}