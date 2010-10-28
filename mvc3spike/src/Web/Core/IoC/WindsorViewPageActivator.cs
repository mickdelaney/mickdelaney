using System;
using System.Web.Mvc;

namespace mvc3spike.Core.IoC
{
    public class WindsorViewPageActivator : IViewPageActivator 
    {
        public object Create(ControllerContext controllerContext, Type type)
        {
            throw new NotImplementedException();
        }
    }
}