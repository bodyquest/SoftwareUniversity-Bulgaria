namespace P01_HospitalDatabase
{
    using Data;

    public class StartUp
    {
        static void Main()
        {
            var db = new HospitalContext();
            db.Database.EnsureCreated();
        }
    }
}
