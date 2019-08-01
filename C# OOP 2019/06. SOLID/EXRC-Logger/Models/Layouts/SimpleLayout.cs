namespace EXRC_Logger.Models.Layouts
{
    using EXRC_Logger.Models.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format
        {
            get
            {
                return "{0} - {1} - {2}";
            }
        }
    }
}
