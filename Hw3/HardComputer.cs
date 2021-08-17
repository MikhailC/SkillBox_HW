using System;

namespace Hw3
{
    public class HardComputer:IUser
    {
        public string Name { get; set; } = "Hard computer";
        public int DoMove(int gameNumber, int minNumber, int maxNumber)
        {
            int tryNumber =  Randomizer.GetRandom(minNumber, maxNumber);
            Console.WriteLine(tryNumber);
            return tryNumber;
            
        }
    
}