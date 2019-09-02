using System;
using System.Collections.Generic;


namespace Composite
{
    abstract class Component
    {
        protected string name;
        
        public Component(string name)
        {
            this.name = name;
        }
        
        public virtual void AddComponent(Component c){}

        public virtual void RemoveComponent(Component c){}

        public virtual void PrintContent()
        {
            Console.WriteLine(name);
        }
    }

    class Directory : Component
    {
        private List<Component> _childs;

        public Directory(string name) : base(name)
        {
            _childs = new List<Component>();
        }

        public override void AddComponent(Component c)
        {
            _childs.Add(c);
        }

        public override void RemoveComponent(Component c)
        {
            _childs.Remove(c);
        }

        public override void PrintContent()
        {
            Console.WriteLine(name);

            foreach(var c in _childs)
                c.PrintContent();
        }
    }

    class File : Component
    {
        public File(string name) : base(name){}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Component fileSystem = new Directory("Файловая система");
            Component discC = new Directory("Диск 'C'");
            Component image1 = new File("someImage1");
            Component image2 = new File("someImage2");

            discC.AddComponent(image1);
            discC.AddComponent(image2);

            fileSystem.AddComponent(discC);

            fileSystem.PrintContent();

            Console.ReadKey();
        }
    }
}