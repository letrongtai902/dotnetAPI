using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using dotnetAPI.Service;
using DotnetAPI.Data;
using DotnetAPI.Data.Infrastructure;
using DotnetAPI.Data.Repositories;
using Microsoft.Owin;
using Owin;
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

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DotnetAPIDbContext>().AsSelf().InstancePerRequest();


            
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();



            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer) container);
        }
    }
}
