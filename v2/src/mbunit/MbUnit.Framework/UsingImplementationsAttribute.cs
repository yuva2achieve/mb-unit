﻿using System;
using System.Reflection;
using System.Collections;
using TestFu.Operations;
using MbUnit.Core;

namespace MbUnit.Framework {
    /// <summary>
    /// Tags a parameter within a [CombinatorialTest]-tagged method to indicate that it should
    /// use all instances of a (parent) type defined within the same assembly as the test for use with the parameter
    /// </summary>
    /// <remarks>
    /// Very handy for passing various types of mock objects into the same test
    /// </remarks>
    /// <example>
    /// <para>In the following example, TestThisObject will be run against an instance of all classes in the same assembly as
    /// this test fixture that derive from TestObject and TestObject itself.</para>
    /// <code>
    ///     [TestFixture]
    ///     public class MyTests 
    ///     {
    ///         [CombinatorialTest]
    ///         public void TestThisObject(
    ///             [UsingImplementations(typeof(TestObject))] TestObject list
    ///             ) 
    ///         {
    ///             ...
    ///         }
    ///     }
    /// </code>
    /// </example>
    /// <seealso cref="CombinatorialTestAttribute"/>
    /// <seealso cref="UsingEnumAttribute"/>
    /// <seealso cref="UsingFactoriesAttribute"/>
    /// <seealso cref="UsingBaseAttribute"/>
    /// <seealso cref="UsingLinearAttribute"/>
    /// <seealso cref="UsingLiteralsAttribute"/>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
    public sealed class UsingImplementationsAttribute : UsingBaseAttribute {
        private Type typeFromAssembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsingImplementationsAttribute"/> class.
        /// </summary>
        /// <param name="typeFromAssembly">The (parent) type to be tested.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="typeFromAssembly"/> is null</exception>
        public UsingImplementationsAttribute(Type typeFromAssembly) {
            if (typeFromAssembly == null)
                throw new ArgumentNullException("typeFromAssembly");
            this.typeFromAssembly = typeFromAssembly;
        }

        /// <summary>
        /// Gets the set of values (the collection of domains) for the parameter.
        /// </summary>
        /// <param name="domains">The <see cref="IDomainCollection"/> the values generated by the source of data</param>
        /// <param name="parameter"><see cref="ParameterInfo"/> for the parameter that wants the values.</param>
        /// <param name="fixture">The test fixture.</param>
        /// <remarks>See <a href="http://blog.dotnetwiki.org/CombinatorialTestingWithTestFu1.aspx">here</a> for more on
        /// domain generation</remarks>
        public override void GetDomains(IDomainCollection domains, ParameterInfo parameter, object fixture) {
            ArrayList types = new ArrayList();
            foreach (Type type in typeFromAssembly.Assembly.GetExportedTypes()) {
                if (type.IsAbstract || type.IsInterface || !type.IsClass)
                    continue;

                if (!parameter.ParameterType.IsAssignableFrom(type))
                    continue;

                // create instance
                Object instance = TypeHelper.CreateInstance(type);
                types.Add(instance);
            }

            CollectionDomain domain = new CollectionDomain(types);
            domain.Name = typeFromAssembly.Assembly.GetName().Name;
            domains.Add(domain);
        }
    }
}
