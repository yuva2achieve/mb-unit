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
using System.IO;

namespace Gallio.Icarus.Models.ProjectTreeNodes
{
    internal sealed class ReportNode : ProjectTreeNode, IEquatable<ReportNode>
    {
        public string FileName
        {
            get;
            private set;
        }

        public ReportNode(string file)
        {
            Text = Path.GetFileNameWithoutExtension(file);
            Image = Properties.Resources.XmlFile.ToBitmap();
            FileName = file;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var reportNode = obj as ReportNode;
            if (reportNode == null)
                return false;

            return Equals(reportNode);
        }

        public override int GetHashCode()
        {
            return FileName.GetHashCode();
        }

        public bool Equals(ReportNode other)
        {
            if (other == null)
                return false;

            return FileName.Equals(other.FileName);
        }
   }
}