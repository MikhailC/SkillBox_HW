using System;

namespace Hw3
{
    public class EasyComputer:IUser
    {
        public string Name { get; set; } = "Easy computer";
        public int DoMove(int gameNumber, int minNumber, int maxNumber)
        {
            int tryNumber =  Randomizer.GetRandom(minNumber, maxNumber);
            Console.WriteLine(tryNumber);
            return tryNumber;
        }

        public override string ToString() => Name;
    }
}