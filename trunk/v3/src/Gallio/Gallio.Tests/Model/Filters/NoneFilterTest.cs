// Copyright 2008 MbUnit Project - http://www.mbunit.com/
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

extern alias MbUnit2;
using Gallio.Tests;
using MbUnit2::MbUnit.Framework;

using Gallio.Model.Filters;

namespace Gallio.Tests.Model.Filters
{
    [TestFixture]
    [TestsOn(typeof(NoneFilter<object>))]
    public class NoneFilterTest : BaseUnitTest
    {
        [Test]
        public void IsMatchReturnsFalse()
        {
            Assert.IsFalse(new NoneFilter<object>().IsMatch(null));
        }

        [RowTest]
        [Row("")]
        [Row("id1212")]
        public void ToStringTest(string id)
        {
            NoneFilter<object> filter = new NoneFilter<object>();
            Assert.AreEqual(filter.ToString(), "None()");
        }
    }
}