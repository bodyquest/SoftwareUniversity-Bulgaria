using System.Text;

using EXRC_Logger.Models.Interfaces;

namespace EXRC_Logger.Models.Layouts
{
    class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            return result.ToString().TrimEnd();
        }
    }
}
