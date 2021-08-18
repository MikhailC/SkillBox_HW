using System;
using System.IO;

namespace Hw3
{
    public class Human: IUser
    {
 
        public string Name { get; set; }

        public int DoMove(Game game)=> 
            Utils.InputValue<int>($"Необходимо ввести число от {game.MinTry} до {game.MaxTry}",
                x => x >= game.MinTry && x <= game.MaxTry);


        public override string ToString()=> $"Игрок {Name}";
        }
    }
