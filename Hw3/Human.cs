using System;

namespace Hw3
{
    public class Human: IUser
    {
 
        public static Human Instance { get; } = new Human();
        public string Name { get; set; }
        public int StepCount { get; private set; } = 0;


        public int DoMove()
        {

            int answer = 0;
            for (;;)
            {
                Console.WriteLine("Введите число от 1 до 4");
                string str = Console.ReadLine();
                try
                {
                    answer = Int32.Parse(str);
                    if (answer <= 0 || answer > 4)
                    {
                        throw new Exception("Неверный формат");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неверное значение. Числа должны быть от 1 до 4");
                    answer = 0;
                    
                }
               
            
            }

            StepCount++;
            return answer;
        }
    }
}