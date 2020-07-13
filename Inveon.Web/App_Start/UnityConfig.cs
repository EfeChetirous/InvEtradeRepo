using Inveon.Data.Context;
using Inveon.Data.Entity;
using Inveon.Data.Repository;
using Inveon.Service.Interfaces;
using Inveon.Service.Services;
using System;

using Unity;
using Unity.AspNet.Mvc;

namespace Inveon.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
             container
                .RegisterType<IRepository<Product>, Repository<Product>>()
                .RegisterType<IRepository<ProductImage>, Repository<ProductImage>>()
                .RegisterType<IProductService, ProductService>()

                .RegisterType<IDataContext, InveonContext>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
        }
    }
}