namespace EXRC_Rectaangle_Intersection
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle
    {
        private int coordinateX;
        private int coordinateY;

        public string Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int PointX { get; set; }

        public int PointY { get; set; }

        public Rectangle(string id)
        {
            this.Id = id;
        }

        public Rectangle(string id, int width, int height, int X, int Y)
        {
            this.Id = id;
            this.PointX = X;
            this.PointY = Y;
            this.Width = width;
            this.Height = height;
        }

        public bool CheckIntersection(Rectangle comparator)
        {
            
            if (comparator.PointX >= this.PointX 
                && comparator.PointX <= this.PointX + this.Width
                && comparator.PointY <= this.PointY + this.Height
                && comparator.PointY >= this.PointY - this.Height)
            {
                return true;
            }

            return false;
        }



    }
}
