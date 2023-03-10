using Autofac.Integration.Mvc;
using Autofac;
using System.Web.Mvc;
using VehicleManagement.UI.Models;
using VehicleManagement.DataAccess;
using VehicleManagement.Core.Models;

namespace VehicleManagement.UI.App_Start
{
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            //// OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            //// OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();

            //// OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            //add 
            builder.RegisterType<DataContext>();
            builder.RegisterType<Repository<User>>().As<IRepository<User>>();
            builder.RegisterType<Repository<Travel>>().As<IRepository<Travel>>();
            builder.RegisterType<Repository<Driver>>().As<IRepository<Driver>>();
            builder.RegisterType<Repository<Vehicle>>().As<IRepository<Vehicle>>();
            builder.RegisterType<Repository<CompleteTravel>>().As<IRepository<CompleteTravel>>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}