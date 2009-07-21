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
using System.Diagnostics;
using System.Text;
using Gallio.Runtime.Logging;

namespace Gallio.Runtime.Debugging
{
    /// <summary>
    /// Provides control over a debugger.
    /// </summary>
    public interface IDebugger
    {
        /// <summary>
        /// Returns true if the debugger is attached to a process.
        /// </summary>
        /// <param name="process">The process to which the debugger should be attached.</param>
        /// <param name="logger">The logger for writing progress and failure messages.</param>
        /// <returns>True if the debugger is already attached.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="process"/> 
        /// or <paramref name="logger"/> is null.</exception>
        bool IsAttachedToProcess(Process process, ILogger logger);

        /// <summary>
        /// Attaches the debugger to a process.
        /// </summary>
        /// <param name="process">The process to which the debugger should be attached.</param>
        /// <param name="logger">The logger for writing progress and failure messages.</param>
        /// <returns>A result code to indicate whether the debugger was attached.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="process"/> 
        /// or <paramref name="logger"/> is null.</exception>
        AttachDebuggerResult AttachToProcess(Process process, ILogger logger);

        /// <summary>
        /// Detaches the debugger from a process.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Does nothing if the process was not attached.
        /// </para>
        /// </remarks>
        /// <param name="process">The process from which the debugger should be detached.</param>
        /// <param name="logger">The logger for writing progress and failure messages.</param>
        /// <returns>A result code to indicate whether the debugger was detached.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="process"/>
        /// or <paramref name="logger"/> is null.</exception>
        DetachDebuggerResult DetachFromProcess(Process process, ILogger logger);
    }
}