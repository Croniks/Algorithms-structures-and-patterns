using System;


namespace ChainResponsibilities
{
    abstract class GameEngineFiles
    {
        public abstract void ShowFiles();
    }

    class UnityFiles : GameEngineFiles
    {
        public override void ShowFiles()
        {
            Console.WriteLine($"Файлы юнити открыты в редакторе Unity!");
        }
    }

    class UnrealEngine4Files : GameEngineFiles
    {
        public override void ShowFiles()
        {
            Console.WriteLine($"Файлы анрил энджин открыты в редакторе UnrealEngine!");
        }
    }

    class CryEngineVFiles : GameEngineFiles
    {
        public override void ShowFiles()
        {
            Console.WriteLine($"Файлы край энджин открыты в редакторе CryEngine!");
        }
    }

    abstract class GameEngine
    {
        public GameEngine NextEngine { get; set; }
        
        public abstract void OpenFile(GameEngineFiles gameFiles);
    }

    class Unity3D : GameEngine
    {
        public override void OpenFile(GameEngineFiles gameFiles)
        {
            if(gameFiles.GetType().Equals(typeof(UnityFiles)))
            {
                gameFiles.ShowFiles();
            }
            else
                NextEngine.OpenFile(gameFiles);
        }
    }
    
    class UnrealEngine4 : GameEngine
    {
        public override void OpenFile(GameEngineFiles gameFiles)
        {
            if (gameFiles.GetType().Equals(typeof(UnrealEngine4Files)))
            {
                gameFiles.ShowFiles();
            }
            else
                NextEngine.OpenFile(gameFiles);
        }
    }

    class CryEngineV : GameEngine
    {
        public override void OpenFile(GameEngineFiles gameFiles)
        {
            if (gameFiles.GetType().Equals(typeof(CryEngineVFiles)))
            {
                gameFiles.ShowFiles();
            }
            else
                NextEngine.OpenFile(gameFiles);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Unity3D unity = new Unity3D();
            UnrealEngine4 unreal = new UnrealEngine4();
            CryEngineV cry = new CryEngineV();
            
            unity.NextEngine = unreal;
            unreal.NextEngine = cry;
            
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