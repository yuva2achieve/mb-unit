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
using System.Text;

namespace Gallio.VisualStudio.Shell.UI.Commands
{
    /// <summary>
    /// Describes the status of a command.
    /// </summary>
    public enum CommandStatus
    {
        /// <summary>
        /// The command is enabled.
        /// </summary>
        Enabled = 0,
        
        /// <summary>
        /// The command is invisible.
        /// </summary>
        Invisible,

        /// <summary>
        /// The command is latched in a toggled 'on' state.
        /// </summary>
        Latched,

        /// <summary>
        /// The command is latched in an untoggled 'off' state.  Opposite of <see cref="Latched"/>.
        /// </summary>
        Ninched
    }
}