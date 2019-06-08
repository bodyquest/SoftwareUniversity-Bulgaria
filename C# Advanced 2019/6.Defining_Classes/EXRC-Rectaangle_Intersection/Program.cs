namespace EXRC_Rectaangle_Intersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<Rectangle> list = new List<Rectangle>();

            int numberOfRectangles = input[0];
            int intersectionChecks = input[1];

            for (int i = 0; i < numberOfRectangles; i++)
            {
                var rectangle = Console.ReadLine().Split(' ').ToArray();
                string id = rectangle[0];
                int width = int.Parse(rectangle[1]);
                int height = int.Parse(rectangle[2]);
                int x = int.Parse(rectangle[3]);
                int y = int.Parse(rectangle[4]);

                Rectangle @object = new Rectangle(id, width, height, x, y);
                list.Add(@object);
            }

            for (int i = 0; i < intersectionChecks; i++)
            {
                var rectanglesToCompare = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string rectangleOne = rectanglesToCompare[0];
                string rectangleTwo = rectanglesToCompare[1];

                Rectangle rect = (from r in list
                              where r.Id.ToString() == rectangleOne
                              select r).SingleOrDefault();

                Rectangle rect2 = list
                    .Where(x => x.Id == rectangleTwo)
                    .SingleOrDefault();

                Console.WriteLine(rect.CheckIntersection(rect2));
            }
            
        }
    }
}
