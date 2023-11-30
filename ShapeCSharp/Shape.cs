using System;

namespace ShapeCSharp
{
    // Абстрактний клас з чисто віртуальними методами
    abstract class Shape
    {
        public abstract void Show();
        public abstract void Area();
        public abstract void Save(string file);
        public abstract void Load(string file);
    }
}