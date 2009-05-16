using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MbUnit.Core.Model;

namespace MbUnit.Framework.Core.Model
{
    /// <summary>
    /// A slot represents a field, property or parameter.  It is used to
    /// simplify the handling of data binding.
    /// </summary>
    public class Slot
    {
        private ICustomAttributeProvider attributeProvider;

        /// <summary>
        /// Initializes a slot from a field.
        /// </summary>
        /// <param name="field">The field</param>
        public Slot(FieldInfo field)
        {
            this.attributeProvider = field;
        }

        /// <summary>
        /// Initializes a slot from a property.
        /// </summary>
        /// <param name="property">The property</param>
        public Slot(PropertyInfo property)
        {
            this.attributeProvider = property;
        }

        /// <summary>
        /// Initializes a slot from a parameter.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        public Slot(ParameterInfo parameter)
        {
            this.attributeProvider = parameter;
        }

        /// <summary>
        /// Gets the custom attribute provider for the associated field, property or parameter, non-null.
        /// </summary>
        public ICustomAttributeProvider AttributeProvider
        {
            get { return attributeProvider; }
        }

        /// <summary>
        /// Gets the associated field, or null if not applicable.
        /// </summary>
        public FieldInfo Field
        {
            get { return attributeProvider as FieldInfo; }
        }

        /// <summary>
        /// Gets the associated property, or null if not applicable.
        /// </summary>
        public PropertyInfo Property
        {
            get { return attributeProvider as PropertyInfo; }
        }

        /// <summary>
        /// Gets the associated parameter, or null if not applicable.
        /// </summary>
        public ParameterInfo Parameter
        {
            get { return attributeProvider as ParameterInfo; }
        }

        /// <summary>
        /// Gets the name of the slot.
        /// </summary>
        public string Name
        {
            get
            {
                MemberInfo member = attributeProvider as MemberInfo;
                if (member != null)
                    return member.Name;

                return Parameter.Name;
            }
        }

        /// <summary>
        /// Gets the type of value held in the slot.
        /// </summary>
        public Type ValueType
        {
            get
            {
                FieldInfo field = Field;
                if (field != null)
                    return field.FieldType;

                PropertyInfo property = Property;
                if (property != null)
                    return property.PropertyType;

                return Parameter.ParameterType;
            }
        }

        /// <summary>
        /// Gets the positional index of a parameter slot, or 0 in other cases.
        /// </summary>
        public int Position
        {
            get
            {
                ParameterInfo parameter = Parameter;
                return parameter != null ? parameter.Position : 0;
            }
        }

        /// <summary>
        /// Gets the code reference for the slot.
        /// </summary>
        public CodeReference CodeReference
        {
            get
            {
                MemberInfo member = attributeProvider as MemberInfo;
                if (member != null)
                    return CodeReference.CreateFromMember(member);

                return CodeReference.CreateFromParameter(Parameter);
            }
        }
    }
}