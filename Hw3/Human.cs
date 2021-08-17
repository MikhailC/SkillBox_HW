using System;
using System.IO;

namespace Hw3
{
    public class Human: IUser
    {
 
        public string Name { get; set; }

        public int DoMove(int gameNumber, int minNumber, int maxNumber)=> 
                Utils.InputValue<int>($"Необходимо ввести число от {minNumber} до {maxNumber}",
                    x => x >= minNumber && x <= maxNumber);
                

             
                    
             
   

        public override string ToString()=> $"Игрок {Name}";
        }
    }
