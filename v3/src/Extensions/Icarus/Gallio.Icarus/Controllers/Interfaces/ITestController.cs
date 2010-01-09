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
using System.Collections.Generic;
using System.ComponentModel;
using Gallio.Common.Concurrency;
using Gallio.Icarus.Models;
using Gallio.Model;
using Gallio.Model.Filters;
using Gallio.Runner;
using Gallio.Runner.Events;
using Gallio.Runner.Reports.Schema;
using Gallio.Runtime.ProgressMonitoring;

namespace Gallio.Icarus.Controllers.Interfaces
{
    public interface ITestController : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the list of currently selected tests.
        /// </summary>
        LockBox<IList<TestTreeNode>> SelectedTests { get; }

        /// <summary>
        /// Indicator if any tests failed during the last run.
        /// </summary>
        bool FailedTests { get; }

        /// <summary>
        /// Gets or sets the current tree category.
        /// </summary>
        string TreeViewCategory { get; set; }

        /// <summary>
        /// Whether or not to filter Passed tests in the tree.
        /// </summary>
        bool FilterPassed { get; set; }
        
        /// <summary>
        /// Whether or not to filter Failed tests in the tree.
        /// </summary>
        bool FilterFailed { get; set; }

        /// <summary>
        /// Whether or not to filter Inconclusive tests in the tree.
        /// </summary>
        bool FilterInconclusive { get; set; }

        /// <summary>
        /// Event raised after each test step completes.
        /// </summary>
        event EventHandler<TestStepFinishedEventArgs> TestStepFinished;

        /// <summary>
        /// Event raised when a test run is started.
        /// </summary>
        event EventHandler RunStarted;

        /// <summary>
        /// Event raised when a test run finishes.
        /// </summary>
        event EventHandler RunFinished;

        /// <summary>
        /// Event raised when test exploration begins.
        /// </summary>
        event EventHandler ExploreStarted;

        /// <summary>
        /// Event raised when test exploration completes.
        /// </summary>
        event EventHandler ExploreFinished;

        /// <summary>
        /// Sets the test runner factory used by the test controller.
        /// </summary>
        /// <param name="factory">The test runner factory to use.</param>
        void SetTestRunnerFactory(ITestRunnerFactory factory);

        /// <summary>
        /// Sets the test package to be used during subsequent calls to <see cref="Explore" /> or <see cref="Run" />.
        /// </summary>
        /// <param name="testPackage">The test package.</param>
        void SetTestPackage(TestPackage testPackage);

        /// <summary>
        /// Acquires a read lock on the report and executes the specified action.
        /// </summary>
        /// <param name="action">The action to execute within the context of the read lock.</param>
        void ReadReport(ReadAction<Report> action);

        /// <summary>
        /// Applies a filter to the tests, potentially altering selections.
        /// </summary>
        /// <param name="filterSet">The filter to apply.</param>
        void ApplyFilterSet(FilterSet<ITestDescriptor> filterSet);

        /// <summary>
        /// Generates a filter from selected tests.
        /// </summary>
        /// <returns>The generated filter.</returns>
        FilterSet<ITestDescriptor> GenerateFilterSetFromSelectedTests();

        /// <summary>
        /// Explores the tests and updates the model, does not run them.
        /// </summary>
        /// <param name="progressMonitor">The progress monitor.</param>
        /// <param name="testRunnerExtensions">A list of test runner extensions to use.</param>
        void Explore(IProgressMonitor progressMonitor, IEnumerable<string> testRunnerExtensions);

        /// <summary>
        /// Runs the tests and updates the model.
        /// </summary>
        /// <param name="debug">If true, runs tests with the debugger.</param>
        /// <param name="progressMonitor">The progress monitor.</param>
        /// <param name="testRunnerExtensions">A list of test runner extensions to use.</param>
        void Run(bool debug, IProgressMonitor progressMonitor, IEnumerable<string> testRunnerExtensions);

        /// <summary>
        /// Refreshes the contents of the test tree based on the tests most recently run or explored.
        /// </summary>
        /// <param name="progressMonitor">The progress monitor.</param>
        void RefreshTestTree(IProgressMonitor progressMonitor);

        /// <summary>
        /// Resets the status of all tests.
        /// </summary>
        void ResetTestStatus(IProgressMonitor progressMonitor);

        /// <summary>
        /// Set the nodes currently selected in the Test Explorer.
        /// </summary>
        /// <param name="nodes">The list of test tree nodes (one normally, but 
        /// could be more if a namespace node is selected (don't ask!)).</param>
        void SetSelection(IList<TestTreeNode> nodes);
    }
}
