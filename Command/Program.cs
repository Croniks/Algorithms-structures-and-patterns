using System;
using System.Collections.Generic;


namespace Command
{
    interface IController
    {
        void PressedX();
        void PressedUp();
        void PressedDown();
    }
    
    class MenuCommand : IController
    {
        private Menu menu;

        public MenuCommand(Menu menu)
        {
            this.menu = menu;
        }

        public void PressedX()
        {
            if (menu != null) menu.СonfirmSelection();
        }

        public void PressedUp()
        {
            if (menu != null) menu.GoToTopMenuItem();
        }

        public void PressedDown()
        {
            if (menu != null) menu.GoToBottomMenuItem();
        }
    }
    
    class Menu
    {
        public void GoToTopMenuItem()
        {
            Console.WriteLine("Переход в верхний пункт меню!");
        }
        
        public void GoToBottomMenuItem()
        {
            Console.WriteLine("Переход в нижний пункт меню!");
        }

        public void СonfirmSelection()
        {
            Console.WriteLine("Подтвердить выбор!");
        }
    }
    
    class GameCommand : IController
    {
        private Game game;

        public GameCommand(Game game)
        {
            this.game = game;
        }

        public void PressedX()
        {
            if (game != null) game.Jump();
        }

        public void PressedUp()
        {
            if (game != null) game.GoForward();
        }

        public void PressedDown()
        {
            if (game != null) game.GoBack();
        }
    }

    class Game
    {
        public void GoForward()
        {
            Console.WriteLine("Идти вперёд!");
        }
        
        public void GoBack()
        {
            Console.WriteLine("Идти назад!");
        }
        
        public void Jump()
        {
            Console.WriteLine("Прыжок!");
        }
    }

    class Gamer
    {
        private List<string> historyCommands;
        private IController[] controllers;

        public Gamer (params IController[] controllers)
        {
            this.controllers = controllers;
            historyCommands = new List<string>();
        }
        
        public void PressX(int i=0)
        {
            if (!(controllers != null && i >= 0 && i < controllers.Length))
                return;

            controllers[i].PressedX();

            historyCommands.Add(System.Reflection.MethodBase.GetCurrentMethod().Name +
                controllers[i].ToString());
        }

        public void PressUp(int i=0)
        {
            if (!(controllers != null && i >= 0 && i < controllers.Length))
                return;

            controllers[i].PressedUp();

            historyCommands.Add(System.Reflection.MethodBase.GetCurrentMethod().Name +
                controllers[i].ToString());
        }

        public void PressDown(int i=0)
        {
            if (!(controllers != null && i >= 0 && i < controllers.Length))
                return;
            
            controllers[i].PressedDown();
            
            historyCommands.Add(System.Reflection.MethodBase.GetCurrentMethod().Name +
                controllers[i].ToString());
        }
        
        public void ShowHistory()
        {
            foreach (string record in historyCommands)
                Console.WriteLine(record);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer = new Gamer( new MenuCommand(new Menu()), new GameCommand(new Game()) );
            
            gamer.PressUp();
            gamer.PressDown();
            gamer.PressX();

            Console.WriteLine(new string('-', 30));

            gamer.PressUp(1);
            gamer.PressDown(1);
            gamer.PressX(1);
            gamer.PressX(1);

            Console.WriteLine(new string('-', 30));

            gamer.ShowHistory();
             
            Console.ReadKey();
        }
    }
}