using System;
using System.Text;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetHtml());
        }

        static string GetHtml()
        {
            dynamic Model =null;
            var html = new StringBuilder();

            html.AppendLine(@"<main class=""mt- 3"">");
            html.AppendLine(@"    <h1 class=""text-center suls-text-color"">Problem Details - " + Model.Name + @"</h1>");
            html.AppendLine(@"    <div class=""top-border-line primary-separator""></div>");
            html.AppendLine(@"    <div class=""text-center suls-text-color"">Problem Submissions</div>");
            html.AppendLine(@"");
            html.AppendLine(@"    <div class=""container-fluid ml-5"">");
            html.AppendLine(@"        <table class=""table table-hover"">");
            html.AppendLine(@"            <thead>");
            html.AppendLine(@"                <tr class=""row"">");
            html.AppendLine(@"                    <th scope=""col"" class=""col-lg-3 suls-text-color"">User</th>");
            html.AppendLine(@"                    <th scope=""col"" class=""col-lg-3 suls-text-color"">Achieved Result</th>");
            html.AppendLine(@"                    <th scope=""col"" class=""col-lg-3 suls-text-color"">Submitted On</th>");
            html.AppendLine(@"                    <th scope=""col"" class=""col-lg-3 suls-text-color"">Delete</th>");
            html.AppendLine(@"                </tr>");
            html.AppendLine(@"            </thead>");
            html.AppendLine(@"            <tbody>");
            html.AppendLine(@"                <tr class=""row"">");
            html.AppendLine(@"                    <td class=""col-lg-3 suls-text-color"">" + problem.Username + @"</td>");
            html.AppendLine(@"                    <td class=""col-lg-3 suls-text-color"">" + problem.AchievedResult + @" / " + problem.MaxPoints + @"</td>");
            html.AppendLine(@"                    <td class=""col-lg-3 suls-text-color"">" + problem.CreatedOn + @"</td>");
            html.AppendLine(@"                    <td class=""col-lg-3 suls-text-color"">");
            html.AppendLine(@"                        <div class=""button-holder"">");
            html.AppendLine(@"                            <a href=""/Submissions/Delete?id=" + problem.SubmissionId + @""" class=""btn btn-warning"">Delete</a>");
            html.AppendLine(@"                        </div>");
            html.AppendLine(@"                    </td>");
            html.AppendLine(@"                </tr>");
            html.AppendLine(@"            </tbody>");
            html.AppendLine(@"        </table>");
            html.AppendLine(@"    </div>");
            html.AppendLine(@"</main>");
            html.AppendLine(@"");


            return html.ToString();
        }
    }
}
