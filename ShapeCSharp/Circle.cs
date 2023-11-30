using System;

namespace ShapeCSharp
{
    class Circle : Shape
    {
        private double centerX, centerY, radius;

        public Circle()
        {
            centerX = 0;
            centerY = 0;
            radius = 0;
        }

        public Circle(double centerX, double centerY, double radius)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
        }

        public double Radius
        {
            get { return radius; }
        }

        public override void Show()
        {
            Console.WriteLine("Коло з центром ({0},{1}) i радiусом {2}", centerX, centerY, radius);
        }
    }
}
