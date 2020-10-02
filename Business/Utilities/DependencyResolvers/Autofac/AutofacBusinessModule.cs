using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Services;
using Business.Utilities.Aspects;
using Business.Utilities.Nlog;
using Castle.DynamicProxy;
using Core.Security;
using Core.Utilities.JsonConverter;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfProductDal<ShopContext>>().As<IProductDal>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<EfSpecificationDal<ShopContext>>().As<ISpecificationDal>().SingleInstance();
            builder.RegisterType<SpecificationManager>().As<ISpecificationService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<EfOrderDal<ShopContext>>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<EfCartDal<ShopContext>>().As<ICartDal>().SingleInstance();
            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<EfCommentDal<ShopContext>>().As<ICommentDal>().SingleInstance();
            builder.RegisterType<ICommentManager>().As<ICommentService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<EfEmailListDal>().As<IEmailListDal>().SingleInstance();
            builder.RegisterType<EfFeedbackDal>().As<IFeedbackDal>().SingleInstance();
            builder.RegisterType<AdminManager>().As<IAdminService>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<LoggerManager>().As<ILoggerService>().SingleInstance();
            
            builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();

            builder.RegisterType<EfFavoriteDal<ShopContext>>().As<IFavoriteDal>().SingleInstance();

            builder.RegisterType<AccountManager>().As<IAccountService>().InstancePerDependency().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));

            builder.RegisterType<JwtHelper>();

            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerDependency();

            builder.RegisterType<Logger>();

        }
    }
}
