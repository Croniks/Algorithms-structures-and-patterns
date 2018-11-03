using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Prototype
{
    [Serializable]
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    [Serializable]
    class Rectangle : IFigure
    {
        int width;
        int height;

        public Point Point { get; set; }

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
            Point = new Point(2, 4);
        }

        public IFigure Clone()
        {
            return MemberwiseClone() as IFigure;
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}," +
                " в точке ({2}, {3})", height, width, Point.X, Point.Y);
        }
    }

    [Serializable]
    class Circle : IFigure
    {
        int radius;
        public Point Point { get; set; }

        public Circle(int r)
        {
            radius = r;
            Point = new Point(6, 8);
        }

        public IFigure Clone()
        {
            return MemberwiseClone() as IFigure;
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
        
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0} " +
                "в точке ({1}, {2})", radius, Point.X, Point.Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();

            ((Rectangle)clonedFigure).Point.X = 1;
            ((Rectangle)clonedFigure).Point.Y = 1;
            
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.WriteLine(new string('-', 52));

            figure = new Rectangle(30, 40);
            clonedFigure = ((Rectangle)figure).DeepCopy() as IFigure;

            ((Rectangle)clonedFigure).Point.X = 1;
            ((Rectangle)clonedFigure).Point.Y = 1;

            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();
        }
    }
}
