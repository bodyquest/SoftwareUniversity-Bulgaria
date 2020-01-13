namespace SIS.MvcFramework.Attributes
{
    using SIS.HTTP.Enums;
    using System;

    public abstract class BaseHttpAttribute : Attribute
    {
        public string ActionName { get; set; }

        public string Url { get; set; }

        public abstract HttpRequestMethod Method{ get; }
    }
}
