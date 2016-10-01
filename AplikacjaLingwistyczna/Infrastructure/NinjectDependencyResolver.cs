using Core.Factories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace AplikacjaLingwistyczna.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParams)
        {
            _kernel = kernelParams;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IFactory>().To<Factory>();
        }
    }
}