[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VideoNotes.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VideoNotes.Web.App_Start.NinjectWebCommon), "Stop")]

namespace VideoNotes.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using VideoNotes.DataAccess;
    using VideoNotes.Service;
    using VideoNotes.Service.Cotracts;
    using VideoNotes.Core.Entities;
    using VideoNotes.Validation;
    using VideoNotes.Validation.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<INoteService>().To<NoteService>();
            kernel.Bind<IVideoService>().To<VideoService>();
            kernel.Bind<ISearchService>().To<SearchService>();

            
            Func<Type, IValidator> validatorFactory = type =>
            {
                var valType = typeof(Validator<>).MakeGenericType(type);
                return (IValidator)kernel.Get(valType);
            };

            kernel.Bind<IValidationProvider>().ToConstant(new ValidationProvider(validatorFactory));
            
            kernel.Bind(typeof(Validator<>)).To(typeof(DefaultValidator<>));

            kernel.Bind<Validator<Category>>().To<CategoryValidator>();
            kernel.Bind<Validator<Note>>().To<NoteValidator>();
            kernel.Bind<Validator<Video>>().To<VideoValidator>();
           
        }        
    }
}
