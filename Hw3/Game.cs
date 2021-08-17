using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace Hw3
{
    public static class Game
    {

        public static int MinGameNumber { get; set; }
        public static int MaxGameNumber { get; set; }
        public static int MinUserTry { get; set; }
        public static int MaxUserTry { get; set; }
        public static int GameNumber { get; private set; } 
        public static List<IUser> Gamers { get; } = new List<IUser>();
        public static IUser Winner { get; private set; } = null;
        
        public static bool Standoff { get; private set; }=false;

        public static int StepNumber { get; private set; } 

        private static int MaxTry => Math.Min(GameNumber, MaxUserTry);

        private static int MinTry => MinUserTry; //Пока не придумал
        public static void Run()
        {
            GameNumber = Randomizer.GetRandom(MinGameNumber,MaxGameNumber);
            Winner = null;
            
            Console.WriteLine($"Начальное GameNumber = {GameNumber}");
            StepNumber = 0;
            while (GameNumber > MinGameNumber)
            {
                IUser user = Gamers[StepNumber++ % Gamers.Count];
       
                Console.WriteLine($"Ход {StepNumber} для {user.Name} Введите число от {MinTry} до {MaxTry}");
                int userTry = user.DoMove(GameNumber, MinTry, MaxTry);
                GameNumber -= userTry;
                Console.WriteLine($"GameNumber = {GameNumber}");
        
                if (GameNumber != MinGameNumber) 
                    continue;
                Winner = user;
                break;
            }

  
         
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