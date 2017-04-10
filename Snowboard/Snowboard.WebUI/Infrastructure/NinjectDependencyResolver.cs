using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Snowboard.Domain.Abstract;
using Snowboard.Domain.Concrete;
using Snowboard.Domain.Entities;

namespace Snowboard.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRoot>().To<Root>();
            kernel.Bind<ISnowboardContext>().To<SnowboardContext>();
            kernel.Bind<IRepositoryBase<Role>>().To<EFRepositoryBase<Role>>();
            kernel.Bind<IRepositoryBase<Snowboard.Domain.Entities.Snowboard>>().To<EFRepositoryBase<Snowboard.Domain.Entities.Snowboard>>();
            kernel.Bind<IRepositoryBase<User>>().To<EFRepositoryBase<User>>();
        }
    }
}