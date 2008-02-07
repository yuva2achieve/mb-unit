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

using MbUnit.Framework;

namespace Gallio.Icarus.Tests
{
    [TestFixture]
    public class SettingsTest
    {
        private Settings settings;

        [SetUp]
        public void SetUp()
        {
            settings = new Settings();
        }

        [Test]
        public void RestorePreviousSettings_Test()
        {
            Assert.IsTrue(settings.RestorePreviousSettings);
            settings.RestorePreviousSettings = false;
            Assert.IsFalse(settings.RestorePreviousSettings);
        }

        [Test]
        public void Clone_Test()
        {
            settings.RestorePreviousSettings = false;
            Assert.IsFalse(settings.RestorePreviousSettings);
            Settings clonedSettings = settings.Clone();
            Assert.IsFalse(clonedSettings.RestorePreviousSettings);
            settings.RestorePreviousSettings = true;
            Assert.IsTrue(settings.RestorePreviousSettings);
            Assert.IsFalse(clonedSettings.RestorePreviousSettings);
        }
    }
}
