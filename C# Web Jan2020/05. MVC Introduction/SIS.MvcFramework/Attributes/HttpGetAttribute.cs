namespace SIS.MvcFramework.Attributes
{
    using SIS.HTTP.Enums;

    public class HttpGetAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Get;
    }
}
