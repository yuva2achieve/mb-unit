// Copyright (c) 2007 mbunit.com
//
// This software is provided 'as-is', without any express or implied warranty. 
// 
// In no event will the authors be held liable for any damages arising from 
// the use of this software.
// Permission is granted to anyone to use this software for any purpose, 
// including commercial applications, and to alter it and redistribute it 
// freely, subject to the following restrictions:
//
//		1. The origin of this software must not be misrepresented; 
//		you must not claim that you wrote the original software. 
//		If you use this software in a product, an acknowledgment in the product 
//		documentation would be appreciated but is not required.
//
//		2. Altered source versions must be plainly marked as such, and must 
//		not be misrepresented as being the original software.
//
//		3. This notice may not be removed or altered from any source 
//		distribution.
//		
//		MbUnit HomePage: http://www.mbunit.com

using System;

using MbUnit.Core.Framework;
using MbUnit.Core.Invokers;

namespace MbUnit.Framework 
{
	/// <summary>
	/// Tags test methods that are ignored.
	/// </summary>
	/// <include file="MbUnit.Framework.Doc.xml" path="doc/remarkss/remarks[@name='IgnoreAttribute']"/>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class IgnoreAttribute : DecoratorPatternAttribute
    {
		public IgnoreAttribute(string description)
			:base(description)
		{}


		public IgnoreAttribute()
			:base("")
		{}

		public override IRunInvoker GetInvoker(MbUnit.Core.Invokers.IRunInvoker wrapper) 
		{
			return new IgnoreRunInvoker(wrapper);			
		}
	}
}