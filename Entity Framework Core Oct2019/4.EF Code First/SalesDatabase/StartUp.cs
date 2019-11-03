namespace P03_SalesDatabase
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new SalesContext())
            {
                db.Database.Migrate();
            }


        }
    }
}
