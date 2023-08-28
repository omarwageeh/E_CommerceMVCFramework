using Autofac;
using Autofac.Integration.Mvc;
using E_Commerce.Data.Context;
using E_Commerce.Repository.Interface;
using E_Commerce.Repository.Repository;
using E_Commerce.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace E_Commerce.MVC.App_Start
{
    public static class ContainerConfig
    {
        internal static void RegisterContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerRequest();
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerRequest();
            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerRequest();
            builder.RegisterType<OrderDetailsRepository>()
                .As<IOrderDetailsRepository>()
                .InstancePerRequest();
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerRequest();
            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
            builder.RegisterType<DataContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}