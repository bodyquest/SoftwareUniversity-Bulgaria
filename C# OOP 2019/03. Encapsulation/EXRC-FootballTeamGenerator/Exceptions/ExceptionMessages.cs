namespace EXRC_FootballTeamGenerator.Exceptions
{
    public class ExceptionMessages
    {
        public static string IvalidStatException = "{0} should be between {1} and {2}.";

        public static string EmptyNameException = "A name should not be empty.";

        public static string MissingPlayerException = "Player {0} is not in {1} team.";

        public static string MissingTeamException = "Team {0} does not exist.";
    }
}
