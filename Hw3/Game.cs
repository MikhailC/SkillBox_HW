using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace Hw3
{
    public  class Game
    {

        public int MinGameNumber { get; set; }
        public int MaxGameNumber { get; set; }
        public int MinUserTry { get; set; }
        public int MaxUserTry { get; set; }
        public int GameNumber { get; private set; } 
        public List<IUser> Gamers { get; } = new List<IUser>();
        public IUser Winner { get; private set; } = null;
        
        public bool Standoff { get; private set; }=false;

        public int StepNumber { get; private set; } 

        public int MaxTry => Math.Min(GameNumber-MinGameNumber, MaxUserTry);

        public int MinTry => Math.Min(GameNumber-MinGameNumber, MinUserTry); 
        public void Run()
        {
            GameNumber = Randomizer.GetRandom(MinGameNumber,MaxGameNumber);
            Winner = null;
            
            Console.WriteLine($"Начальное GameNumber = {GameNumber}");
            StepNumber = 0;
            while (GameNumber > MinGameNumber)
            {
                IUser user = Gamers[StepNumber++ % Gamers.Count];
       
                Console.WriteLine($"Ход {StepNumber} для {user.Name} Введите число от {MinTry} до {MaxTry}");
                int userTry = user.DoMove(Instance);
                GameNumber -= userTry;
                Console.WriteLine($"GameNumber = {GameNumber}");
        
                if (GameNumber != MinGameNumber) 
                    continue;
                Winner = user;
                break;
            }

            if (Winner == null) Standoff = true;

        }

        //Singleton with lazy init
        private static Game _instance=null;
        
        public static Game Instance
        {
            get
            {
                if (_instance == null) _instance = new Game();
                return _instance;
            }
        }

        private Game()
        {
            
        }
        
        public static void PrintInstruction()
        {
            String Instruction = "--------------------------------------------------------------------\n" +
                                 "Компьютер задумывает любое число в заданном диапазоне GameNumber\n" +
                                 "Игроки называют по очереди число UserTry в заданном диапазоне\n" +
                                 "Выигрывает тот, кто достигнет минимального числа GameNumber\n" +
                                 "\n" +
                                 "Вы можете играть неограниченным количеством игроков\n" +
                                 "Если вы решите сыграть 1, то вы можете выбрать сложность игры с Компьютером,\n" +
                                 "А также кто будет ходить первым \n\n" +
                                 "----------------------------Нажмите Enter----------------------------\n";
            Console.WriteLine(Instruction);
            Console.ReadLine();
            Console.Clear();
        }

    }
}