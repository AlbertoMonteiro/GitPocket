using Microsoft.Practices.ServiceLocation;
using Ninject.Syntax;

namespace GitPocket.IoC
{
    public interface INinjectServiceLocator : IServiceLocator
    {
        IBindingToSyntax<T> Bind<T>();
    }
}