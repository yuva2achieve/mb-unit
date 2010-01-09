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

using Gallio.Icarus.Controllers.Interfaces;
using Gallio.Icarus.Events;
using Gallio.Icarus.Projects;
using Gallio.Icarus.Properties;
using Gallio.Runtime.ProgressMonitoring;
using Gallio.UI.ProgressMonitoring;

namespace Gallio.Icarus.Commands
{
    internal class OpenProjectCommand : ICommand
    {
        private readonly ITestController testController;
        private readonly IProjectController projectController;
        private readonly IEventAggregator eventAggregator;
        private readonly LoadPackageCommand loadPackageCommand;
        private readonly RestoreFilterCommand restoreFilterCommand;

        public string FileName { get; set; }

        public OpenProjectCommand(ITestController testController, IProjectController projectController, 
            IEventAggregator eventAggregator)
        {
            this.testController = testController;
            this.projectController = projectController;
            this.eventAggregator = eventAggregator;

            loadPackageCommand = new LoadPackageCommand(testController, projectController);
            restoreFilterCommand = new RestoreFilterCommand(testController, projectController);
        }

        public void Execute(IProgressMonitor progressMonitor)
        {
            using (progressMonitor.BeginTask(Resources.OpeningProject, 100))
            {
                using (var subProgressMonitor = progressMonitor.CreateSubProgressMonitor(5))
                    testController.ResetTestStatus(subProgressMonitor);

                using (var subProgressMonitor = progressMonitor.CreateSubProgressMonitor(5))
                    projectController.OpenProject(FileName, subProgressMonitor);

                using (var subProgressMonitor = progressMonitor.CreateSubProgressMonitor(85))
                    loadPackageCommand.Execute(subProgressMonitor);

                using (var subProgressMonitor = progressMonitor.CreateSubProgressMonitor(5))
                    restoreFilterCommand.Execute(subProgressMonitor);

                eventAggregator.Send(new ProjectOpened(FileName));
            }
        }
    }
}
