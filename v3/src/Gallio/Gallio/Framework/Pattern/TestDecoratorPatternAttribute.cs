// Copyright 2005-2008 Gallio Project - http://www.gallio.org/
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
using Gallio.Reflection;
using Gallio.Framework.Pattern;

namespace Gallio.Framework.Pattern
{
    /// <summary>
    /// <para>
    /// A test decorator pattern attribute applies decorations to an
    /// existing assembly, type or method level <see cref="PatternTest" />.
    /// </para>
    /// </summary>
    /// <seealso cref="TestTypePatternAttribute"/>
    [AttributeUsage(PatternAttributeTargets.Test, AllowMultiple = true, Inherited = true)]
    public abstract class TestDecoratorPatternAttribute : DecoratorPatternAttribute
    {
        /// <inheritdoc />
        public override void Process(PatternEvaluationScope scope, ICodeElementInfo codeElement)
        {
            Validate(scope, codeElement);

            scope.AddDecorator(Order, delegate
            {
                DecorateTest(scope, codeElement);
            });
        }

        /// <summary>
        /// Verifies that the attribute is being used correctly.
        /// </summary>
        /// <param name="scope">The scope</param>
        /// <param name="codeElement">The code element</param>
        /// <exception cref="PatternUsageErrorException">Thrown if the attribute is being used incorrectly</exception>
        protected virtual void Validate(PatternEvaluationScope scope, ICodeElementInfo codeElement)
        {
            if (!scope.IsTestDeclaration)
                ThrowUsageErrorException("This attribute can only be used on a test.");
        }

        /// <summary>
        /// <para>
        /// Applies decorations to a method or type-level <see cref="PatternTest" />.
        /// </para>
        /// <para>
        /// A typical use of this method is to augment the test with additional metadata
        /// or to add additional behaviors to the test.
        /// </para>
        /// </summary>
        /// <param name="scope">The scope</param>
        /// <param name="codeElement">The code element</param>
        protected virtual void DecorateTest(PatternEvaluationScope scope, ICodeElementInfo codeElement)
        {
        }
    }
}