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
using System.Text;

namespace Gallio.Model.Filters
{
    /// <summary>
    /// A filter combinator that matches a value when at least one of its constituent filters
    /// matches the value.
    /// </summary>
    [Serializable]
    public class OrFilter<T> : Filter<T>
    {
        private readonly Filter<T>[] filters;

        /// <summary>
        /// Creates an OR-filter.
        /// </summary>
        /// <param name="filters">The filters from which at least one match must be found.
        /// If the array is empty, the filter matches everything.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="filters"/> is null</exception>
        public OrFilter(Filter<T>[] filters)
        {
            if (filters == null)
                throw new ArgumentNullException("filters");

            this.filters = filters;
        }

        /// <summary>
        /// Gets the filters from which at least one match must be found.
        /// If the array is empty, the filter matches everything.
        /// </summary>
        public Filter<T>[] Filters
        {
            get { return filters; }
        }

        /// <inheritdoc />
        public override bool IsMatch(T value)
        {
            return filters.Length == 0 || Array.Exists(filters, delegate(Filter<T> filter)
            {
                return filter.IsMatch(value);
            });
        }

        /// <inheritdoc />
        public override void Accept(IFilterVisitor visitor)
        {
            visitor.VisitOrFilter(this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(@"Or({ ");

            for (int i = 0; i < filters.Length; i++)
            {
                if (i != 0)
                    result.Append(@", ");

                result.Append(filters[i]);
            }

            result.Append(@" })");
            return result.ToString();
        }
    }
}