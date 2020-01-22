namespace SIS.MvcFramework.Attributes
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using SIS.HTTP.Enums;

    public class HttpPutAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Put;
    }
}
