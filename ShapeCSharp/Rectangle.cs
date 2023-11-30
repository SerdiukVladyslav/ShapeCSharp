using System;

namespace ShapeCSharp
{
    // Тут усе так само, щоби я не повторювався
    class Rectangle : Shape
    {
        private double x1, y1, x2, y2;

        public Rectangle()
        {
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
        }

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public double X1
        {
            get { return x1; }
        }

        public double Y1
        {
            get { return y1; }
        }

        public double X2
        {
            get { return x2; }
        }

        public double Y2
        {
            get { return y2; }
        }

        public override void Show()
        {
            Console.WriteLine("Прямокутник з координатами ({0},{1}) i ({2},{3})", x1, y1, x2, y2);
        }

        public override void Area()
        {
            double S = (x2 - x1) * (y2 - y1);
            Console.WriteLine("Площа прямокутника: {0}", S);
        }

        public override void Save(string file)
        {
            Console.WriteLine("Збереження прямокутника у файл: " + file);
        }

        public override void Load(string file)
        {
            Console.WriteLine("Завантаження прямокутника з файлу: " + file);
        }
    }
}
