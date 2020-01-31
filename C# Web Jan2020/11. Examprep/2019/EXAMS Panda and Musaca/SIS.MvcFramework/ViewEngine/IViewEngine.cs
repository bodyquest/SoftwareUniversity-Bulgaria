namespace SIS.MvcFramework.ViewEngine
{
    using Validation;

    using SIS.MvcFramework.Identity;

    public interface IViewEngine
    {
        string GetHtml<T>(string viewContent, T model, ModelStateDictionary modelState, Principal user);
    }
}
