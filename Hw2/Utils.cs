using System;

namespace Hw2
{
    public static class Utils
    {
        /// <summary>
        /// Ввод через консоль переменной определенного типа
        /// </summary>
        /// <param name="caption">Напоминание пользователю того что он должен ввести</param>
        /// <param name="errorText">В случае ошибки ввода будет выведено сообщение переданное в этом параметре</param>
        /// <param name="test">Лямбда выражение для проверки результата</param>
        /// <typeparam name="T">Вводимый тип переменной</typeparam>
        /// <returns>Возврщается значение приведенное к заданному типу и с пройденной валидацией</returns>
        public static T InputValue<T>(string caption, string errorText, Func<T,bool> test)
        {
            T answer;

            for(;;)
            {
                Console.WriteLine(caption);
                string str = Console.ReadLine();

                try
                {
                    answer = (T) Convert.ChangeType(str, typeof(T));
                    if (test(answer))
                    {
                        return answer;
                    }
                    else
                    {
                        Console.Error.WriteLine(errorText);
                    }
                    
                }
                catch
                {
                    Console.Error.WriteLine(errorText);
                }

                
            } ;

            return answer;


        }
    }
}