

using System;
using Hw3;

namespace Hw7
{

    

    class Program
    {
        
        static void Main(string[] args)
        {
           
            while (true)
            {
                Command c = GetCommand();
                if(c==Command.Exit) return;

                Diary.Actions[c].Invoke();

            }
          
            

        }
        
        public static Command GetCommand()
        {
      
            
                Console.WriteLine("Введите соответствующий пункт меню и нажмите Enter");
                Console.WriteLine("1. Показать заметки");
                Console.WriteLine("2. Вставить заметку");
                Console.WriteLine("3. Редактировать заметку");
                Console.WriteLine("------------------------");
                Console.WriteLine("4. Удалить по индексу");
                Console.WriteLine("5. Удалить по полю");
                Console.WriteLine("------------------------");
                Console.WriteLine("6. Сохранить");
                Console.WriteLine("7. Сохранить как...");
                Console.WriteLine("------------------------");
                Console.WriteLine("8. Загрузить");
                Console.WriteLine("9. Загрузить по диапазону дат");
                Console.WriteLine("------------------------");
                Console.WriteLine("10. Упорядочить по полю");
                Console.WriteLine("11. Выход");

               return (Command) Utils.InputValue<int>("Укажите значение пункта", x => x > 0 && x < 12)-1;
                
         
            
        }

    }
}