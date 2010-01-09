// Copyright 2005-2010 Gallio Project - http://www.gallio.org/
// Portions Copyright 2000-2004 Jonathan de Halleux
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

using System;
using System.Xml;
using Gallio.ReSharperRunner.Provider.Facade;

namespace Gallio.ReSharperRunner.Provider.Tasks
{
    /// <summary>
    /// This task specifies that a test has been explicitly selected to run.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It should always appear after <see cref="GallioTestRunTask" />.
    /// </para>
    /// </remarks>
    [Serializable]
    public class GallioTestExplicitTask : FacadeTask, IEquatable<GallioTestExplicitTask>
    {
        private readonly string testId;

        public GallioTestExplicitTask(string testId)
        {
            this.testId = testId;
        }

        public GallioTestExplicitTask(XmlElement element)
            : base(element)
        {
            testId = element.GetAttribute("testId");
        }

        public string TestId
        {
            get { return testId; }
        }

        public override void SaveXml(XmlElement element)
        {
            base.SaveXml(element);

            element.SetAttribute("testId", testId);
        }

        public bool Equals(GallioTestExplicitTask other)
        {
            return other != null && testId == other.testId;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GallioTestExplicitTask);
        }

        public override int GetHashCode()
        {
            return testId.GetHashCode();
        }
    }
}