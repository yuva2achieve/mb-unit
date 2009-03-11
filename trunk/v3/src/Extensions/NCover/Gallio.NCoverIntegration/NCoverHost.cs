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
using Gallio.Runtime.Logging;
using Gallio.Concurrency;
using Gallio.Runtime.Hosting;

namespace Gallio.NCoverIntegration
{
    /// <summary>
    /// An NCover host is a variation on a <see cref="IsolatedProcessHost" />
    /// launches the process with the NCover profiler attached.
    /// </summary>
    public class NCoverHost : IsolatedProcessHost
    {
        private readonly NCoverVersion version;

        /// <summary>
        /// Creates an uninitialized host.
        /// </summary>
        /// <param name="hostSetup">The host setup</param>
        /// <param name="logger">The logger for host message output</param>
        /// <param name="installationPath">The runtime installation path where the hosting executable will be found</param>
        /// <param name="version">The NCover version</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="hostSetup"/> 
        /// <paramref name="logger"/>, or <paramref name="installationPath"/> is null</exception>
        public NCoverHost(HostSetup hostSetup, ILogger logger, string installationPath, NCoverVersion version)
            : base(hostSetup, logger, installationPath)
        {
            this.version = version;
        }

        /// <inheritdoc />
        protected override ProcessTask CreateProcessTask(string executablePath, string arguments, string workingDirectory)
        {
            switch (version)
            {
                case NCoverVersion.V1:
                    return new EmbeddedNCoverProcessTask(executablePath, arguments, workingDirectory, Logger);

                case NCoverVersion.V2:
                    return NCoverTool.CreateProcessTask(executablePath, arguments, workingDirectory, 2);

                case NCoverVersion.V3:
                    return NCoverTool.CreateProcessTask(executablePath, arguments, workingDirectory, 3);

                default:
                    throw new NotSupportedException("Unrecognized NCover version.");
            }
        }
    }
}