﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1378
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MbUnit.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MbUnit.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MbUnit v{0}.
        /// </summary>
        internal static string MbUnitFrameworkTemplate_MbUnitGallioFrameworkVersionFormat {
            get {
                return ResourceManager.GetString("MbUnitFrameworkTemplate_MbUnitGallioFrameworkVersionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error while binding value for parameter &apos;{0}&apos;..
        /// </summary>
        internal static string MbUnitTestState_ErrorWhileBindingValueForParameter {
            get {
                return ResourceManager.GetString("MbUnitTestState_ErrorWhileBindingValueForParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The template binding does not contain parameter &apos;{0}&apos;..
        /// </summary>
        internal static string MbUnitTestState_TemplateBindingDoesNotContainParameter {
            get {
                return ResourceManager.GetString("MbUnitTestState_TemplateBindingDoesNotContainParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected to invoke an instance method of a fixture but the fixture instance is not available..
        /// </summary>
        internal static string MbUnitTestUtils_ExpectedToInvokeAnInstanceMethod {
            get {
                return ResourceManager.GetString("MbUnitTestUtils_ExpectedToInvokeAnInstanceMethod", resourceCulture);
            }
        }
    }
}
