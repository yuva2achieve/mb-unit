﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallio.Collections;
using Gallio.Runtime.Extensibility;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Gallio.Tests.Runtime.Extensibility
{
    [TestsOn(typeof(SingletonHandlerFactory))]
    public class SingletonHandlerFactoryTest
    {
        [Test]
        public void CreateHandler_WhenContractTypeNotSatisfiedByObjectType_Throws()
        {
            var factory = new SingletonHandlerFactory();
            var serviceLocator = MockRepository.GenerateStub<IServiceLocator>();
            var resourceLocator = MockRepository.GenerateStub<IResourceLocator>();

            var ex = Assert.Throws<RuntimeException>(() => factory.CreateHandler(serviceLocator, resourceLocator,
                typeof(IService), typeof(ComponentThatDoesNotImplementIService), new PropertySet()));
            Assert.AreEqual(string.Format("Could not satisfy contract of type '{0}' by creating an instance of type '{1}'.",
                typeof(IService), typeof(ComponentThatDoesNotImplementIService)), ex.Message);
        }

        [Test]
        public void CreateHandler_WhenArgumentsValid_ReturnsAHandlerThatGeneratesTheSameComponentInstanceEachTime()
        {
            var factory = new SingletonHandlerFactory();
            var serviceLocator = MockRepository.GenerateStub<IServiceLocator>();
            var resourceLocator = MockRepository.GenerateStub<IResourceLocator>();

            var handler = factory.CreateHandler(serviceLocator, resourceLocator,
                typeof(IService), typeof(Component), new PropertySet());

            var instance1 = handler.Activate();
            Assert.IsInstanceOfType<Component>(instance1);

            var instance2 = handler.Activate();
            Assert.AreSame(instance1, instance2, "Should return same instance each time because the component is considered a singleton.");
        }

        private interface IService
        {
        }

        private class Component : IService
        {
        }

        private class ComponentThatDoesNotImplementIService
        {
        }
    }
}
