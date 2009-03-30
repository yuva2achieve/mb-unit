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
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace MbUnit.Samples.ContractVerifiers
{
    public class SampleEquatableTest
    {
        [ContractVerifier]
        public readonly IContractVerifier EqualityTests = new VerifyEqualityContract<SampleEquatable>()
        {
            ImplementsOperatorOverloads = true, // Optional (default is true)
            EquivalenceClasses = EquivalenceClassCollection<SampleEquatable>.FromDistinctInstances(
                new SampleEquatable(1),
                new SampleEquatable(2),
                new SampleEquatable(3),
                new SampleEquatable(4),
                new SampleEquatable(5)),
        };
    }
}