﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.IoC
{
    public enum Lifetime
    {
        /// <summary>Represents a component is a transient component.
        /// </summary>
        Transient,
        /// <summary>Represents a component is a singleton component.
        /// </summary>
        Singleton,
        //
        // Summary:
        //     A LifetimeManager that holds onto the instance given
        //     to it during the lifetime of a single HTTP request. This lifetime manager enables
        //     you to create instances of registered types that behave like singletons within
        //     the scope of an HTTP request. See remarks for important usage information.
        //
        // Remarks:
        //     Although the PerRequestLifetimeManager lifetime manager
        //     works correctly and can help in working with stateful or thread-unsafe dependencies
        //     within the scope of an HTTP request, it is generally not a good idea to use it
        //     when it can be avoided, as it can often lead to bad practices or hard to find
        //     bugs in the end-user's application code when used incorrectly. It is recommended
        //     that the dependencies you register are stateless and if there is a need to share
        //     common state between several objects during the lifetime of an HTTP request,
        //     then you can have a stateless service that explicitly stores and retrieves this
        //     state using the System.Web.HttpContext.Items collection of the System.Web.HttpContext.Current
        //     object.
        //     For the instance of the registered type to be disposed automatically when the
        //     HTTP request completes, make sure to register the Microsoft.Practices.Unity.Mvc.UnityPerRequestHttpModule
        //     with the web application. To do this, invoke the following in the Unity bootstrapping
        //     class (typically UnityMvcActivator.cs): DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        PerRequest,
        /// <summary>
        /// A special lifetime manager which works like ContainerControlledLifetimeManager,
        //  except that in the presence of child containers, each child gets it's own instance
        //  of the object, instead of sharing one in the common parent.
        /// </summary>
        Hierarchical
    }
}
