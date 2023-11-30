using System;

namespace ShapeCSharp
{
    class Triangle : Shape
    {
        // Полі
        private double cathetus1;
        private double cathetus2;

        // Конструктор без параметрів
        public Triangle()
        {
            cathetus1 = 0;
            cathetus2 = 0;
        }

        // Конструктор з параметрами
        public Triangle(double cathetus1, double cathetus2)
        {
            this.cathetus1 = cathetus1;
            this.cathetus2 = cathetus2;
        }

        // Властивості
        public double Cathetus1
        {
            get { return cathetus1; }
        }

        public double Cathetus2
        {
            get { return cathetus1; }
        }

        // Вивід на екран інформацію про фігуру
        public override void Show()
        {
            Console.WriteLine("Трикутник з катетом 1 = {0} i катетом 2 = {1}", cathetus1, cathetus2);
        }

        // Вичислення площі
        public override void Area()
        {
            double S = 0.5 * cathetus1 * cathetus2;
            Console.WriteLine("Площа трикутника: {0}", S);
        }

        public override void Save(string file)
        {
            Console.WriteLine("Збереження трикутника у файл: " + file);
        }

        public override void Load(string file)
        {
            Console.WriteLine("Завантаження трикутника з файлу: " + file);
        }
    }
}
