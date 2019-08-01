namespace EXRC_Logger.Models.Layouts
{
    using System.Text;

    using EXRC_Logger.Models.Interfaces;

    public class JSONLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("\"lpg\":[")
                .AppendLine("\t\"date\": \"{0}\",")
                .AppendLine("\t\"level\": \"{1}\",")
                .AppendLine("\t\"message\": \"{2}\",")
                .AppendLine("]");

            return result.ToString().TrimEnd();
        }
    }
}
