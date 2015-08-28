using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;

namespace MultipleConnectionString.Utilities
{
    public static class AutofacHelper
    {
        public static T Resolve<T>(this IDependencyResolver container, Parameter[] paramsCtor = null)
        {
            var rawContainer = (AutofacDependencyResolver)DependencyResolver.Current;
            return rawContainer.ApplicationContainer.Resolve<T>(paramsCtor); //((IEnumerable<Parameter>)paramsCtor);
        }

        public static T ResolveByNamed<T>(this IDependencyResolver context, string serviceName)
        {
            var rawContainer = (AutofacDependencyResolver)DependencyResolver.Current;
            return rawContainer.ApplicationContainer.ResolveNamed<T>(serviceName);
        }
    }
}