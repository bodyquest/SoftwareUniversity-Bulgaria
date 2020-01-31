using System;

namespace SIS.MvcFramework.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationSisAttribute : Attribute
    {
        protected ValidationSisAttribute(string errorMessage = "Invalid input\r\n")
        {
            this.ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public abstract bool IsValid(object value);
    }
}
