using System;
using DAL.RepositoryInterfaces;
using Unity;
using DAL.Repositories;
using DAL.UnitOfWork;
using Shared.Interfaces;
using BLL;

namespace RishavBookReadingEventManagement
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
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IBusinessLayerUser,BusinessLayerUser>();
            container.RegisterType<IUserUnitOfWork, UserUnitOfWork>();
            container.RegisterType<IBusinessLayerBookReadingEvent, BusinessLayerBookReadingEvent>();
            container.RegisterType<IBookReadingEventUnitOfWork,BookReadingEventUnitOfWork>();
            container.RegisterType<IBusinessLayerPostedComments,BusinessLayerPostedComments>();
            container.RegisterType<IPostedCommentUnitOfWork, PostCommentUnitOfWork>();
            container.RegisterType<IBookReadingEventRepositories,BookReadingEventRepository>();
            container.RegisterType<IUserRepositories,UserRepository>();
            container.RegisterType<IPostedCommentRepository, PostedCommentRepository>();
        }
    }
}