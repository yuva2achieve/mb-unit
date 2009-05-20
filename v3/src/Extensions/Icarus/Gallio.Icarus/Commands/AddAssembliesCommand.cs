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
using System.Collections.Generic;
using System.Windows.Forms;
using Gallio.Icarus.Controllers.Interfaces;
using Gallio.Runtime.ProgressMonitoring;

namespace Gallio.Icarus.Commands
{
    internal class AddAssembliesCommand : ICommand
    {
        private readonly IProjectController projectController;
        private readonly ITestController testController;

        private readonly string fileFilter = "Assemblies or Executables (*.dll, *.exe)|*.dll;*.exe|All Files (*.*)|*.*";

        public IList<string> AssemblyFiles
        {
            get;
            set;
        }

        public AddAssembliesCommand(IProjectController projectController, ITestController testController)
        {
            this.projectController = projectController;
            this.testController = testController;
        }

        public void Execute(IProgressMonitor progressMonitor)
        {
            if (AssemblyFiles == null)
            {
                using (var openFileDialog = new OpenFileDialog
                {
                    Filter = fileFilter,
                    Multiselect = true
                })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        AssemblyFiles = openFileDialog.FileNames;
                }
            }
            using (progressMonitor.BeginTask("Adding assemblies", 100))
            {
                // add assemblies to test package
                using (var subProgressMonitor = progressMonitor.CreateSubProgressMonitor(10))
                    projectController.AddAssemblies(AssemblyFiles, subProgressMonitor);

                if (progressMonitor.IsCanceled)
                    throw new OperationCanceledException();

                // reload tests
                using (var subProgressMonitor = progressMonitor.CreateSubProgressMonitor(90))
                {
                    testController.SetTestPackageConfig(projectController.TestPackageConfig);
                    testController.Explore(subProgressMonitor, projectController.TestRunnerExtensions);
                }
            }
        }
    }
}