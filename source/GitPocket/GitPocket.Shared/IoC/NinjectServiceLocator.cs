using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Syntax;

namespace GitPocket.IoC
{
    public class NinjectServiceLocator : INinjectServiceLocator
    {
        readonly StandardKernel kernel;
        static INinjectServiceLocator instance;

        private NinjectServiceLocator()
        {
            kernel = new StandardKernel();
        }

        public static INinjectServiceLocator Default
        {
            get { return instance ?? (instance = new NinjectServiceLocator()); }
            
        }

        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return kernel.Get(serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return kernel.Get<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return kernel.Get<TService>();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return kernel.GetAll<TService>();
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }
    }
}