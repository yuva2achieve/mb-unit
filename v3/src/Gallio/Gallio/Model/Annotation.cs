﻿using System;
using Gallio.Reflection;

namespace Gallio.Model
{
    /// <summary>
    /// An annotation associates a message with a source code location
    /// to inform the user about a problem.
    /// </summary>
    [Serializable]
    public class Annotation
    {
        private readonly AnnotationType type;
        private readonly ICodeElementInfo codeElement;
        private readonly string message;
        private readonly string details;

        /// <summary>
        /// Creates an annotation.
        /// </summary>
        /// <param name="type">The annotation type</param>
        /// <param name="codeElement">The associated code element, or null if none</param>
        /// <param name="message">The annotation message</param>
        /// <param name="details">Additional details such as exception text or null if none</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="message"/> is null</exception>
        public Annotation(AnnotationType type, ICodeElementInfo codeElement, string message, string details)
        {
            this.type = type;
            this.codeElement = codeElement;
            this.message = message;
            this.details = details;
        }

        /// <summary>
        /// Gets the annotation type.
        /// </summary>
        public AnnotationType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Gets the code element associated with the annotation.
        /// </summary>
        public ICodeElementInfo CodeElement
        {
            get { return codeElement; }
        }

        /// <summary>
        /// Gets the annotation message.
        /// </summary>
        public string Message
        {
            get { return message; }
        }

        /// <summary>
        /// Gets additional details such as exception text, or null if none.
        /// </summary>
        public string Details
        {
            get { return details; }
        }
    }
}
