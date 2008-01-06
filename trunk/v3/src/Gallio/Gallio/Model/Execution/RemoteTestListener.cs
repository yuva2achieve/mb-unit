// Copyright 2008 MbUnit Project - http://www.mbunit.com/
// Portions Copyright 2000-2004 Jonathan De Halleux, Jamie Cansdale
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

namespace Gallio.Model.Execution
{
    /// <summary>
    /// A remote test listener is a serializable wrapper for another listener.
    /// The wrapper can be passed to another AppDomain and communication occurs over
    /// .Net remoting.
    /// </summary>
    /// <todo author="jeff">
    /// While it would be great to catch and log exceptions, the question is where.
    /// If we write them out as debug/trace information then we might end up in
    /// a recursive cycle because we trap those writes and send them back in
    /// here.  So we'll die of a StackOverflowException due to some remoting goofiness.
    /// So basically short of inventing a new place to log errors
    /// we're screwed.  -- Jeff.
    /// </todo>
    [Serializable]
    public sealed class RemoteTestListener : ITestListener
    {
        private readonly Forwarder forwarder;

        /// <summary>
        /// Creates a wrapper for the specified listener.
        /// </summary>
        /// <param name="listener">The listener</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="listener"/> is null</exception>
        public RemoteTestListener(ITestListener listener)
        {
            if (listener == null)
                throw new ArgumentNullException(@"listener");

            forwarder = new Forwarder(listener);
        }

        /// <inheritdoc />
        public void NotifyLifecycleEvent(LifecycleEventArgs e)
        {
            forwarder.NotifyTestLifecycleEvent(e);
        }

        /// <inheritdoc />
        public void NotifyLogEvent(LogEventArgs e)
        {
            forwarder.NotifyTestExecutionLogEvent(e);
        }

        /// <summary>
        /// The forwarding event listener forwards events to the host's event listener.
        /// </summary>
        private sealed class Forwarder : MarshalByRefObject
        {
            private readonly ITestListener listener;

            public Forwarder(ITestListener listener)
            {
                this.listener = listener;
            }

            public void NotifyTestLifecycleEvent(LifecycleEventArgs e)
            {
                listener.NotifyLifecycleEvent(e);
            }

            public void NotifyTestExecutionLogEvent(LogEventArgs e)
            {
                listener.NotifyLogEvent(e);
            }
        }
    }
}