namespace _02.DemoCoreMVCApp.TagHelpers
{
    using _02.DemoCoreMVCApp.Services;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [HtmlTargetElement("h1", Attributes ="greeting-name")]
    [HtmlTargetElement("h2")]
    [HtmlTargetElement("h3")]
    [HtmlTargetElement("h4")]
    [HtmlTargetElement("h5")]
    [HtmlTargetElement("h6")]
    public class HelloTagHelper : TagHelper
    {
        private readonly IUsersService usersService;

        public HelloTagHelper(IUsersService userService)
        {
            this.usersService = userService;
        }

        public string GreetingName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Dari", this.GreetingName);
            output.Content.SetContent(this.GreetingName);
            output.PreElement.SetContent(this.GreetingName);
            output.PostContent.SetContent(this.usersService.GetCount().ToString());
        }
    }
}
