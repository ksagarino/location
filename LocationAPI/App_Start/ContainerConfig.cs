
using System.Linq;

using Autofac;

using LocationAPI.Models;
using System.Reflection;

namespace LocationAPI
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LocationDBEntities>().InstancePerRequest();


            //builder.RegisterType<Repositories.Repository<typeof()>>.As<Services.IRepositoryService<TEntity where: TEntity: class>>();

            builder.Build();
        }
    }
}