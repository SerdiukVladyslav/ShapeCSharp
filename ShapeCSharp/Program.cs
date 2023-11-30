using System;
using System.Xml.Serialization;

namespace ShapeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введiть початкову ємнiсть колекцiї: ");
                int capacity = int.Parse(Console.ReadLine()); // Вводимо ємність скільки ми хочемо фігур в масиві

                ShapeCollection shapeCollection = new ShapeCollection(capacity);

                int choice;

                do
                {
                    Menu();

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddShape(shapeCollection);
                            break;
                        case 2:
                            RemoveShape(shapeCollection);
                            break;
                        case 3:
                            ShowAllShapes(shapeCollection);
                            break;
                        case 4:
                            PrintShapesOfType(shapeCollection);
                            break;
                        case 5:
                            CalculateTotalArea(shapeCollection);
                            break;
                        case 6:
                            CalculateTotalAreaOfType(shapeCollection);
                            break;
                        case 7:
                            Save(shapeCollection);
                            break;
                        case 8:
                            Load(shapeCollection);
                            break;
                        case 9:
                            Console.WriteLine("Вихiд...");
                            break;
                        default:
                            Console.WriteLine("Неправильно введено вибiр. Спробуйте ще раз.");
                            break;
                    }
                } while (choice != 9);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Просто меню
        static void Menu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати фiгуру");
            Console.WriteLine("2. Видалити фiгуру");
            Console.WriteLine("3. Роздрукувати всi фiгури");
            Console.WriteLine("4. Роздрукувати фiгури указаного типу");
            Console.WriteLine("5. Вичислити площу всiх фiгур");
            Console.WriteLine("6. Вичислити площу фiгур указаного типу");
            Console.WriteLine("7. Збереження фiгур у файл");
            Console.WriteLine("8. Завантаження фiгур з файлу");
            
            Console.Write("Введiть свiй вибiр: ");
        }

        // Додати трикутник
        static void AddTriangle(ShapeCollection shapeCollection)
        {
            Console.Write("Введiть довжину першого катета: ");
            double cathetus1 = double.Parse(Console.ReadLine());

            Console.Write("Введiть довжину другого катета: ");
            double cathetus2 = double.Parse(Console.ReadLine());

            Triangle triangle = new Triangle(cathetus1, cathetus2);
            shapeCollection.AddShape(triangle);

            Console.WriteLine("Трикутник успiшно доданий.");
        }

        // Додати прямокутник
        static void AddRectangle(ShapeCollection shapeCollection)
        {
            Console.Write("Введiть координату X верхнього лiвого кута: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("Введiть координату Y верхнього лiвого кута: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.Write("Введiть координату X нижнього правого кута: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.Write("Введiть координату Y нижнього правого кута: ");
            double y2 = double.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
            shapeCollection.AddShape(rectangle);

            Console.WriteLine("Прямокутник успiшно доданий.");
        }

        // Додати коло
        static void AddCircle(ShapeCollection shapeCollection)
        {
            Console.Write("Введiть координату центра X: ");
            double centerX = double.Parse(Console.ReadLine());

            Console.Write("Введiть координату центра Y: ");
            double centerY = double.Parse(Console.ReadLine());

            Console.Write("Введiть радiус кола: ");
            double radius = double.Parse(Console.ReadLine());

            Circle circle = new Circle(centerX, centerY, radius);
            shapeCollection.AddShape(circle);

            Console.WriteLine("Коло успiшно додане.");
        }

        // Додати фігуру
        static void AddShape(ShapeCollection shapeCollection)
        {
            Console.WriteLine("Виберiть тип фiгури:");
            Console.WriteLine("1. Трикутник");
            Console.WriteLine("2. Прямокутник");
            Console.WriteLine("3. Коло");

            Console.Write("Ваш вибiр: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddTriangle(shapeCollection);
                    break;
                case 2:
                    AddRectangle(shapeCollection);
                    break;
                case 3:
                    AddCircle(shapeCollection);
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр типу фiгури. Спробуйте ще раз.");
                    break;
            }
        }

        // Видалити фігуру
        static void RemoveShape(ShapeCollection shapeCollection)
        {
            Console.Write("Введiть iндекс фiгури для видалення: ");
            int index = int.Parse(Console.ReadLine());

            bool removed = shapeCollection.RemoveShapeByIndex(index);

            if (removed)
                Console.WriteLine("Фiгуру успiшно видалено з колекцiї.");

            else
                Console.WriteLine("Не вдалося знайти фiгуру за вказаним iндексом.");
        }

        // Роздрукувати всі фігури
        static void ShowAllShapes(ShapeCollection shapeCollection)
        {
            shapeCollection.PrintAllShapes();
        }

        // Роздрукувати фігуру указаного типу
        static void PrintShapesOfType(ShapeCollection shapeCollection)
        {
            Console.WriteLine("Оберiть тип фiгури для друку:");
            Console.WriteLine("1. Трикутник");
            Console.WriteLine("2. Прямокутник");
            Console.WriteLine("3. Коло");
            Console.Write("Ваш вибiр: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Трикутники:");
                    shapeCollection.PrintShapesOfType<Triangle>();
                    break;
                case 2:
                    Console.WriteLine("Прямокутники:");
                    shapeCollection.PrintShapesOfType<Rectangle>();
                    break;
                case 3:
                    Console.WriteLine("Кола:");
                    shapeCollection.PrintShapesOfType<Circle>();
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр.");
                    break;
            }
        }

        // Вичислити площу всіх фігур
        static void CalculateTotalArea(ShapeCollection shapeCollection)
        {
            double totalArea = shapeCollection.CalculateTotalArea();

            Console.WriteLine("Загальна площа всiх фiгур: {0}", totalArea);
        }

        // Вичислити площу фігури указаного типу
        static void CalculateTotalAreaOfType(ShapeCollection shapeCollection)
        {
            Console.WriteLine("Оберiть тип фiгури для вичислення площi:");
            Console.WriteLine("1. Трикутник");
            Console.WriteLine("2. Прямокутник");
            Console.WriteLine("3. Коло");
            Console.Write("Ваш вибiр: ");
            int choice = int.Parse(Console.ReadLine());

            double totalArea = 0;

            switch (choice)
            {
                case 1:
                    totalArea = shapeCollection.CalculateTotalAreaOfType<Triangle>();
                    Console.WriteLine("Загальна площа трикутникiв: " + totalArea);
                    break;
                case 2:
                    totalArea = shapeCollection.CalculateTotalAreaOfType<Rectangle>();
                    Console.WriteLine("Загальна площа прямокутникiв: " + totalArea);
                    break;
                case 3:
                    totalArea = shapeCollection.CalculateTotalAreaOfType<Circle>();
                    Console.WriteLine("Загальна площа кол: " + totalArea);
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр.");
                    break;
            }
        }

        // Збереження
        static void Save(ShapeCollection shapeCollection)
        {
            shapeCollection.Save("Shape.txt");
        }

        // Завантаження
        static void Load(ShapeCollection shapeCollection)
        {
            shapeCollection.Load("Shape.txt");
        }
    }
}