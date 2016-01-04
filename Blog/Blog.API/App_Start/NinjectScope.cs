using Ninject.Activation;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Blog.API.App_Start
{
    public class NinjectScope:IDependencyScope
    {
        #region Properties

        protected IResolutionRoot ResolutionRoot;

        #endregion

        #region Methods

        public NinjectScope(IResolutionRoot kernel)
        {
            ResolutionRoot = kernel;
        }
        public object GetService(Type serviceType)
        {
            IRequest request = ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return ResolutionRoot.Resolve(request).SingleOrDefault();
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return ResolutionRoot.Resolve(request).ToList();
        }
        public void Dispose()
        {
            IDisposable disposable = (IDisposable)ResolutionRoot;
            if (disposable != null) disposable.Dispose();
            ResolutionRoot = null;
        }

        #endregion
    }
}