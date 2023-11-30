using System;
using System.IO;

namespace ShapeCSharp
{
    class ShapeCollection
    {
        private Shape[] shapes;
        private int count;

        // Конструктор приймає ємність колекції
        public ShapeCollection(int capacity)
        {
            shapes = new Shape[capacity];
            count = 0;
        }

        // Додати фігуру
        public void AddShape(Shape shape)
        {
            if (count < shapes.Length)
            {
                shapes[count] = shape;
                count++;
                Console.WriteLine("Фiгуру додано.");
            }

            else
                Console.WriteLine("Колекцiя фiгур повна. Неможливо додати ще.");
        }

        // Знаходимо індекс фігури для видалення
        public bool RemoveShapeByIndex(int index)
        {
            if (index >= 0 && index < count)
            {
                shapes[index] = null;
                return true;
            }

            return false;
        }

        // Видалити фігуру
        public void RemoveShape(Shape shape)
        {
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (shapes[i] == shape)
                {
                    for (int j = i; j < count - 1; j++)
                        shapes[j] = shapes[j + 1];

                    count--;
                    found = true;
                    break;
                }
            }

            if (found)
                Console.WriteLine("Фiгуру видалено.");

            else
                Console.WriteLine("Фiгуру не знайдено в колекцiї.");
        }

        // Роздрукувати всі фігури
        public void PrintAllShapes()
        {
            Console.WriteLine("Роздрукування всiх фiгур:");

            for (int i = 0; i < count; i++)
                shapes[i].Show();
        }

        // Роздрукувати фігуру указаного типу
        public void PrintShapesOfType<T>() // T - це сама фігура
        {
            for (int i = 0; i < count; i++)
            {
                if (shapes[i] is T)
                    shapes[i].Show();
            }
        }

        // Вичислити площу всіх фігур
        private static double CalculateArea(Shape shape)
        {
            if (shape is Triangle triangle)
                return 0.5 * triangle.Cathetus1 * triangle.Cathetus2;

            else if (shape is Rectangle rectangle)
                return (rectangle.X2 - rectangle.X1) * (rectangle.Y2 - rectangle.Y1);

            else if (shape is Circle circle)
                return 3.14159 * circle.Radius * circle.Radius;

            else
            {
                Console.WriteLine("Невiдома фiгура.");
                return 0;
            }
        }

        public double CalculateTotalArea()
        {
            double totalArea = 0;

            for (int i = 0; i < count; i++)
            {
                Shape shape = shapes[i];

                if (shape != null)
                    totalArea += CalculateArea(shape);
            }

            return totalArea;
        }

        // Вичислити площу фігури указаного типу
        public double CalculateTotalAreaOfType<T>()
        {
            double totalArea = 0;

            for (int i = 0; i < count; i++)
            {
                Shape shape = shapes[i];

                if (shape is T)
                    totalArea += CalculateArea(shape);
            }

            return totalArea;
        }

        // Збереження фігури у файл
        public void Save(string file)
        {
            try
            {
                StreamWriter writer = new StreamWriter(file);

                for (int i = 0; i < count; i++)
                {
                    Shape shape = shapes[i];

                    if (shape != null)
                    {
                        // Записуємо рядок з даними фігури у файл
                        writer.WriteLine(shape.ToString());
                    }
                }

                writer.Close();

                Console.WriteLine("Фiгури успiшно збережено у файл: {0}\n", file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Завантаження фігури з файлу
        public void Load(string file)
        {
            try
            {
                StreamReader reader = new StreamReader(file);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Розбиваємо рядок на окремі значення
                    string[] values = line.Split(',');

                    if (values.Length > 0)
                    {
                        string shapeType = values[0];

                        // Залежно від типу фігури створюємо відповідний об'єкт фігури
                        Shape shape;

                        if (shapeType == "Triangle")
                        {
                            // Отримуємо значення катетів
                            double cathetus1 = double.Parse(values[1]);
                            double cathetus2 = double.Parse(values[2]);

                            // Створюємо трикутник
                            shape = new Triangle(cathetus1, cathetus2);
                        }

                        else if (shapeType == "Rectangle")
                        {
                            // Отримуємо значення координат
                            double x1 = double.Parse(values[1]);
                            double y1 = double.Parse(values[2]);
                            double x2 = double.Parse(values[3]);
                            double y2 = double.Parse(values[4]);

                            // Створюємо прямокутник
                            shape = new Rectangle(x1, y1, x2, y2);
                        }

                        else if (shapeType == "Circle")
                        {
                            // Отримуємо значення координат центра і радіус
                            double centerX = double.Parse(values[1]);
                            double centerY = double.Parse(values[2]);
                            double radius = double.Parse(values[3]);

                            // Створюємо коло
                            shape = new Circle(centerX, centerY, radius);
                        }

                        else
                        {
                            // Невідомий тип фігури, ігноруємо рядок
                            continue;
                        }

                        // Додавання створеної фігури до масиву
                        AddShape(shape);
                    }
                }

                reader.Close();

                Console.WriteLine("Фiгури успiшно завантажено з файлу: {0}\n", file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
