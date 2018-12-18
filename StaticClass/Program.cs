using System;


namespace StaticClass
{
    class Camera
    {
        private static Camera main;

        public static Camera Main
        {
            get
            {
                if(Main is null)
                    return main;
                return main;
            }
            set { }
        }

        public Camera() {}

        public void PrintOne() { Console.WriteLine(1); }

        private static void TryFindCamera() { Main = new Camera(); }
    }
    
    
    class Program
    {
        public static void Main(string[] args)
        {
            Camera someCamera = new Camera();
            Camera.Main?.PrintOne();
            
            Console.ReadKey();
        }
    }
}
