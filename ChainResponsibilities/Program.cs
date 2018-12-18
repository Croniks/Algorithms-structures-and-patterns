using System;


namespace ChainResponsibilities
{
    abstract class GameEngineFiles
    {
        public abstract void ShowFiles(string str);
    }

    class UnityFiles : GameEngineFiles
    {
        public override void ShowFiles(string str)
        {
            Console.WriteLine($"Файлы юнити открыты в редакторе {str}!" );
        }
    }

    class UnrealEngine4Files : GameEngineFiles
    {
        public override void ShowFiles(string str)
        {
            Console.WriteLine($"Файлы анрил энджин открыты в редакторе {str}!");
        }
    }

    class CryEngineVFiles : GameEngineFiles
    {
        public override void ShowFiles(string str)
        {
            Console.WriteLine($"Файлы край энджин открыты в редакторе {str}!");
        }
    }

    abstract class GameEngine
    {
        public GameEngine Engine { get; set; }
        
        public abstract void OpenFile(GameEngineFiles gameFiles);
    }

    class Unity3D : GameEngine
    {
        public override void OpenFile(GameEngineFiles gameFiles)
        {
            if(gameFiles.GetType().Equals(typeof(UnityFiles)))
            {
                gameFiles.ShowFiles("Unity3D");
            }
            else
                Engine.OpenFile(gameFiles);
        }
    }
    
    class UnrealEngine4 : GameEngine
    {
        public override void OpenFile(GameEngineFiles gameFiles)
        {
            if (gameFiles.GetType().Equals(typeof(UnrealEngine4Files)))
            {
                gameFiles.ShowFiles("UnrealEngine4");
            }
            else
                Engine.OpenFile(gameFiles);
        }
    }

    class CryEngineV : GameEngine
    {
        public override void OpenFile(GameEngineFiles gameFiles)
        {
            if (gameFiles.GetType().Equals(typeof(CryEngineVFiles)))
            {
                gameFiles.ShowFiles("CryEngineV");
            }
            else
                Engine.OpenFile(gameFiles);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Unity3D unity = new Unity3D();
            UnrealEngine4 unreal = new UnrealEngine4();
            CryEngineV cry = new CryEngineV();
            
            unity.Engine = unreal;
            unreal.Engine = cry;
            
            UnityFiles unityFiles = new UnityFiles();
            UnrealEngine4Files unrealFiles = new UnrealEngine4Files();
            CryEngineVFiles cryFiles = new CryEngineVFiles();

            unity.OpenFile(unityFiles);
            unity.OpenFile(unrealFiles);
            unity.OpenFile(cryFiles);

            Console.ReadKey();
        }
    }
}
