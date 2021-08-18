using System;
using System.Diagnostics;

namespace Hw3
{
    public class HardComputer : IUser
    {
        public string Name { get; set; } = "Hard computer";

        public int DoMove(Game game)
        {
            //Не важно как ходит пользователь и компьютер, важно последние два хода думать
            //1. Сделать на максимальное число +1 ход для компьютера
            
          //  Game.GameNumber

          int realNumber = game.GameNumber - game.MinGameNumber;
          int tryNumber;
          int borderNumber = game.MaxTry * 2 + game.MinTry;
          
          
          //По правилам игры нужно иногда тупить
          //Тупим) 
          bool stupidStep = (Randomizer.GetRandom(1, 100) > 90);
          Debug.WriteLine($"Real number: {realNumber} borderNumber {borderNumber} stupid step {stupidStep}");

       if (realNumber > borderNumber||stupidStep)
       {
               tryNumber = Randomizer.GetRandom(game.MinTry, game.MaxTry);
       }  
       else if (realNumber <= game.MaxTry)
       {
           tryNumber = realNumber;
       }else
       {
           tryNumber = realNumber - (game.MaxTry+game.MinTry+1);
       }

       ;
        
       Console.WriteLine(tryNumber);

         
       return tryNumber;
        }
    }

}