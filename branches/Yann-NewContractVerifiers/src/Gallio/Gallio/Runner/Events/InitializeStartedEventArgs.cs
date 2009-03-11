// Copyright 2005-2008 Gallio Project - http://www.gallio.org/
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

namespace Gallio.Runner.Events
{
    /// <summary>
    /// Arguments for an event raised to indicate that the test runner initialization has started.
    /// </summary>
    public sealed class InitializeStartedEventArgs : OperationStartedEventArgs
    {
        private readonly TestRunnerOptions options;

        /// <summary>
        /// Initializes the event arguments.
        /// </summary>
        /// <param name="options">The test runner options</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="options"/> is null</exception>
        public InitializeStartedEventArgs(TestRunnerOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            this.options = options;
        }

        /// <summary>
        /// Gets the test runner options.
        /// </summary>
        public TestRunnerOptions Options
        {
            get { return options; }
        }
    }
}