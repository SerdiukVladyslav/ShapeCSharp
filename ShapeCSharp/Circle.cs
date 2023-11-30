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

        public override void Area()
        {
            // 3.14159 - число пі. Радіус помножено на радіус, оскільки це радіус в квадраті (радіус у 2-му степені)
            double S = 3.14159 * radius * radius;
            Console.WriteLine("Площа кола: {0}", S);
        }

        public override void Save(string file)
        {
            Console.WriteLine("Збереження кола у файл: " + file);
        }

        public override void Load(string file)
        {
            Console.WriteLine("Завантаження кола з файлу: " + file);
        }
    }
}
