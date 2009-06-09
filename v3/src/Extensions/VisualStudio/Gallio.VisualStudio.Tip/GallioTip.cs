// Copyright 2005-2009 Gallio Project - http://www.gallio.org/
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
using System.Collections;
using System.IO;
using Gallio.Common.Collections;
using Gallio.Model;
using Gallio.Model.Serialization;
using Gallio.Runtime;
using Gallio.Common.Reflection;
using Gallio.Runtime.Loader;
using Microsoft.VisualStudio.TestTools.Common;
using TestResult=Microsoft.VisualStudio.TestTools.Common.TestResult;

namespace Gallio.VisualStudio.Tip
{
    /// <summary>
    /// Integrates the Gallio test model as an extension for MSTest.
    /// This enables MSTest to run Gallio tests and to display them in the IDE.
    /// </summary>
    public class GallioTip : Microsoft.VisualStudio.TestTools.Common.Tip
    {
        private readonly ITmi tmi;

        public GallioTip(ITmi tmi)
        {
            if (tmi == null)
                throw new ArgumentNullException("tmi");

            this.tmi = tmi;
        }

        public override ICollection Load(string location, ProjectData projectData, IWarningHandler warningHandler)
        {
            // Skip loading if the extension is not fully initalized.
            if (!TipShellExtension.IsInitialized)
                return EmptyArray<TestElement>.Instance;

            // Explore the tests.
            ITestFrameworkManager frameworkManager = RuntimeAccessor.ServiceLocator.Resolve<ITestFrameworkManager>();
            WarningLogger logger = new WarningLogger(warningHandler);

            TestPackageConfig testPackageConfig = new TestPackageConfig();
            testPackageConfig.ExcludedFrameworkIds.Add("MSTestAdapter.TestFramework");

            testPackageConfig.AssemblyFiles.Add(location);

            ReflectionOnlyAssemblyLoader loader = new ReflectionOnlyAssemblyLoader();
            loader.AddHintDirectory(Path.GetDirectoryName(location));

            ITestExplorer explorer = frameworkManager.GetTestExplorer(frameworkId => testPackageConfig.IsFrameworkRequested(frameworkId));
            TestPackage testPackage = new TestPackage(testPackageConfig, loader.ReflectionPolicy,
                RuntimeAccessor.ServiceLocator.Resolve<ILoader>());
            TestModel testModel = new TestModel(testPackage);
                
            IAssemblyInfo assembly = loader.ReflectionPolicy.LoadAssemblyFrom(location);
            TestSource testSource = new TestSource();
            testSource.AddAssembly(assembly);
            explorer.Explore(testModel, testSource, null);

            ArrayList tests = new ArrayList();
            foreach (ITest test in testModel.AllTests)
            {
                if (test.IsTestCase)
                    tests.Add(GallioTestElementFactory.CreateTestElement(new TestData(test), location, projectData));
            }

            foreach (Annotation annotation in testModel.Annotations)
                new AnnotationData(annotation).Log(logger, true);

            return tests;
        }

        public override void Save(ITestElement[] tests, string location, ProjectData projectData)
        {
            throw new NotSupportedException();
        }

        public override TestResult MergeResults(TestResult inMemory, TestResultMessage fromTheWire)
        {
            // Use the base code for merging results.
            TestResult testResult = base.MergeResults(inMemory, fromTheWire);

            // If the base code did not handle our result type, then do extra work.
            GallioTestResult gallioTestResult = testResult as GallioTestResult;
            if (gallioTestResult == null)
            {
                gallioTestResult = new GallioTestResult(testResult);

                GallioTestResult source = inMemory as GallioTestResult;
                if (source != null)
                    gallioTestResult.MergeFrom(source);
            }

            return gallioTestResult;
        }

        public override TestType TestType
        {
            get { return Guids.GallioTestType; }
        }
    }
}