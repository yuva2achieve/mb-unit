// Copyright 2007 MbUnit Project - http://www.mbunit.com/
// Portions Copyright 2000-2004 Jonathan De Halleux, Jamie Cansdale
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace MbUnit.Framework
{
    using System;
    using System.Reflection;
    using System.Collections;
    using TestDriven.UnitTesting;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class TestFixtureSetUpAttribute : Attribute, ITestCaseFactory
    {
        public ITestCase[] CreateTests(ITestFixture fixture, MethodInfo method)
        {
            object fixtureObject = fixture.CreateInstance();
            return new ITestCase[] { new TestFixtureSetUpTestCase(fixture.Name, method, fixtureObject) };
        }

        class TestFixtureSetUpTestCase : MethodTestCase
        {
            object fixtureObject;

            public TestFixtureSetUpTestCase(string fixtureName, MethodInfo method, object fixtureObject)
                : base(fixtureName, method)
            {
                this.fixtureObject = fixtureObject;
            }

            public override void Run(object fixture)
            {
                base.Run(this.fixtureObject);
            }
        }
    }
}