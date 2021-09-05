using System;
using System.Diagnostics;
using System.Net.Mime;
using Microsoft.VisualBasic;

namespace Hw3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Game.PrintInstruction();

            int usersNumber = Utils.InputValue<int>("Может быть только целое число", x => x>0,
                "Сколько пользователей будет играть в игру?");
            
            for (int i = 0; i < usersNumber; i++)
            {
                Console.WriteLine($"Введите имя пользователя {i+1}");
                IUser user = new Human() {Name = Console.ReadLine()};
                Game.Instance.Gamers.Add(user);
            }

            if (usersNumber == 1)
            {
                int cumputerLevel = Utils.InputValue<int>("Сейчас можно выбрать только из двух уровней",
                    x => x == 1 || x == 2, "Введите уровень игры компьютера 1- легкий, 2- тяжелый");

                IUser computer = cumputerLevel switch
                {
                    1 => new EasyComputer(),
                    2 => new HardComputer(),
                    _=> throw new Exception("Мы вводим только правильные переменные, эта фраза на всякий случай")
                };

                int computerOreder = Utils.InputValue<int>("Можно выбрать 1 или 2", x => x == 1 || x == 2,
                    "Компьютер ходит первым (1) или вторым (2)");
                
                Game.Instance.Gamers.Insert(computerOreder-1, computer);
                
               
            }
            
            Game.Instance.MinGameNumber = Utils.InputValue<int>("Минимальное число должно быть больше нуля", x => x > 0, "Введите минимальное число gameNumber");
            Game.Instance.MaxGameNumber = Utils.InputValue<int>($"Число должно быть больше чем {Game.Instance.MinGameNumber}", x => x > Game.Instance.MinGameNumber, "Введите максимальнео числое gameNumber");

            Game.Instance.MinUserTry = Utils.InputValue<int>("Должно быть больше нуля",
                x => x > 0 && x<Game.Instance.MaxGameNumber, "Введите минимальное число userTry");
            Game.Instance.MaxUserTry = Utils.InputValue<int>($"Должно быть больше {Game.Instance.MinUserTry}", x => x > Game.Instance.MinUserTry&& x<Game.Instance.MaxGameNumber, "Введите максимальнео число userTry");

            do
            {
                //   int GameNumber = new Random((int) DateTime.Now.Ticks & 0x0000FFFF).Next(minGameNumber-1, maxGameNumber) + 1;

                Game.Instance.Run();

                if (Game.Instance.Standoff)
                {
                    Console.WriteLine("Ничья");

                }
                else
                {
                    Console.WriteLine($"Победитель {Game.Instance.Winner}");
                }

    
                Console.WriteLine("Повторим (Y/N)?");
                
            } while (Console.ReadKey().KeyChar.ToString().ToLower().Equals("y"));





        }
    }
}