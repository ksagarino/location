
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Http;
using LocationAPI.Models;

namespace LocationAPI
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<LocationDBEntities>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repositories.Repository<>)).As(typeof(Services.IRepositoryService<>));
            builder.RegisterType<Repositories.LocationRepository>().As<Services.ILocationService>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            config.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }
    }
}