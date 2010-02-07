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
using System.ComponentModel;
using Gallio.Icarus.Controllers.EventArgs;
using Gallio.Icarus.Controls;

namespace Gallio.Icarus.Controllers
{
    internal interface IApplicationController : INotifyPropertyChanged
    {
        string Title { get; set; }
        ToolStripMenuItem[] RecentProjects { get; }
        bool FailedTests { get; }

        event EventHandler<FileChangedEventArgs> FileChanged;

        void Load();
        void NewProject();
        void OpenProject(string projectName);
        void SaveProject(bool queueTask);
    }
}