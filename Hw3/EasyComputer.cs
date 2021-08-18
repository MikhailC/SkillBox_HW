using System;

namespace Hw3
{
    public class EasyComputer:IUser
    {
        public string Name { get; set; } = "Easy computer";

        public int DoMove(Game game)
        {
            int tryNumber =  Randomizer.GetRandom(game.MinTry, game.MaxTry);
            Console.WriteLine(tryNumber);
            return tryNumber;
        }

        public override string ToString() => Name;
    }
}