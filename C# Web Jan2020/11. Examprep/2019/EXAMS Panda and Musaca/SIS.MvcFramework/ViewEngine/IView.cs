namespace SIS.MvcFramework.ViewEngine
{
    using Validation;

    using SIS.MvcFramework.Identity;

    public interface IView
    {
        string GetHtml(object model, ModelStateDictionary modelState, Principal user);
    }
}
