using Ninject;
using NUnit.Framework;
using Restponder.App_Start;
using Restponder.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace DummyAPI.Tests.Controllers
{
    [TestFixture]
    public class ControllerBindingsTests
    {
        private IKernel _kernel;

        [OneTimeSetUp]
        public void Init()
        {
            _kernel = new StandardKernel(new RestponderNinjectModule());
        }

        [TestCaseSource(typeof(ControllerTypes))]
        public void ControllerConstructorTest(Type controllerType)
        {
            Assert.IsNotNull(_kernel.Get(controllerType));
        }

        private class ControllerTypes : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                return FindDerivedTypes(Assembly.GetAssembly(typeof(DummyController)), typeof(ApiController)).GetEnumerator();
            }

            public IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
            {
                return assembly.GetTypes().Where(t => t != baseType &&
                                                      baseType.IsAssignableFrom(t));
            }
        }
    }
}