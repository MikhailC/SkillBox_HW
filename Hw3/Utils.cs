using System;

namespace Hw3
{
    public static class Utils
    {
        /// <summary>
        /// Ввод через консоль переменной определенного типа
        /// </summary>
        /// <param name="errorText">В случае ошибки ввода будет выведено сообщение переданное в этом параметре</param>
        /// <param name="test">Лямбда выражение для проверки результата</param>
        /// <param name="caption">Напоминание пользователю того что он должен ввести</param>
        /// <typeparam name="T">Вводимый тип переменной</typeparam>
        /// <returns>Возврщается значение приведенное к заданному типу и с пройденной валидацией</returns>
        public static T InputValue<T>(string errorText, Func<T, bool> test,  string caption="")
        {
            T answer;

            while(true)
            {
                if (caption.Length!=0) Console.WriteLine(caption);
              
                string str = Console.ReadLine();

         
                    try
                    {
                        answer = (T) Convert.ChangeType(str, typeof(T));
                        if (test is null || test(answer))
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
                }

            // } 
        }
    }
}