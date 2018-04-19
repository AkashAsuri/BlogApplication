using BlogApplication.DAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogApplication.Infrastructure
{
    public class NinjectDIFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;
        public NinjectDIFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IBlogRepository>().To<BlogRepository>();
        }

    }
}