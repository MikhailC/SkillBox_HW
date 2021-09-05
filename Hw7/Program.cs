

using System;

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
            Command? result = null;
            
            do
            {
                Console.WriteLine("Нажмите соответствующую клавишу для выбора или Esc для выхода");
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
                var answer = Console.ReadKey();
                
                if (answer.Key == ConsoleKey.Escape) 
                    return Command.Exit;
                try
                {
                    if (Enum.IsDefined(typeof(Command), int.Parse(answer.KeyChar.ToString())))
                        result = (Command) int.Parse(answer.KeyChar.ToString()) - 1;
                }
                catch
                {
                    Console.WriteLine("Неверное значение. Выбрите значение из меню. Любая кнопка для продолжения...");
                    Console.ReadKey();
                }


            } while (result is null);
            //Command.ListNotes
            Console.WriteLine(result);
            return result.Value;
            
        }

    }
}