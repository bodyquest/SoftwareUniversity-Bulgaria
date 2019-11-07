namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;

    public class SartUp
    {
        public static void Main()
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.EnsureCreated();

                //context.Database.Migrate();
            }
        }
    }
}
