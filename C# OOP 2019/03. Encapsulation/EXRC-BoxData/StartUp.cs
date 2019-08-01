namespace EXRC_ClassBoxData
{
    using System;

    using EXRC_ClassBoxData.Models;

    public class StartUp
    {
        static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);
                Console.WriteLine(box.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
