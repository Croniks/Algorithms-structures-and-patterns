using System;


namespace Factory_Method
{ 
    public abstract class Shoe
    {
        public abstract string GetName();
        public abstract int GetSize();
    }

    public class Sneakers : Shoe
    {
        public string Name { get; private set; }
        private int size;

        public Sneakers (int size=50) { this.size = size; Name = "Кроссовки";}
        public override int GetSize() { return size; }
        public override string GetName() { return Name; }
    }

    public class Sandals : Shoe
    {
        public string Name { get; private set; }
        private int size;

        public Sandals(int size = 50) { this.size = size; Name = "Сандали"; }
        public override int GetSize() { return size; }
        public override string GetName() { return Name; }
    }

    public abstract class Shoemaker
    {
        public abstract Shoe CreateShoe();
    }

    public class SandalsMaker : Shoemaker
    {
        public override Shoe CreateShoe() { return new Sandals(); }
    }

    public class SneakersMaker : Shoemaker
    {
        public override Shoe CreateShoe() { return new Sneakers(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shoemaker shoeMaker = new SneakersMaker();
            Shoe shoes1 = shoeMaker.CreateShoe();

            shoeMaker = new SandalsMaker();
            Shoe shoes2 = shoeMaker.CreateShoe();

            Console.WriteLine(shoes1.GetSize());
            Console.WriteLine(shoes1.GetName());

            Console.WriteLine(shoes2.GetSize());
            Console.WriteLine(shoes2.GetName());

            Console.ReadKey();
        }
    }
}
