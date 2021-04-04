using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using dotnetAPI.Model.Models;
using dotnetAPI.Service;
using dotnetAPI.Service.AccessRequestMediator;
using DotnetAPI.Data;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories;
using MediatR;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(dotnetAPI.Host.App_Start.Startup))]

namespace dotnetAPI.Host.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();



            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DotnetAPIDbContext>().AsSelf().InstancePerRequest();
            

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();


            //builder.RegisterAssemblyTypes(typeof(PostAcessRequest<Customer>).GetTypeInfo().Assembly).AsImplementedInterfaces();
             builder.RegisterAssemblyTypes(typeof(PostAcessRequest<>).GetTypeInfo().Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(GetRequest<>).GetTypeInfo().Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(IRequestHandler<GetRequest<Customer>,Customer>).GetTypeInfo().Assembly).AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(IRequest<>)).AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(IRequestHandler<,>)).AsImplementedInterfaces();



            builder.RegisterAssemblyTypes(typeof(IRequestHandler<,>).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IRequest<>).GetTypeInfo().Assembly).AsImplementedInterfaces();


            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();


            

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            Autofac.IContainer container = builder.Build();

        

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer) container);
        }
    }
}
