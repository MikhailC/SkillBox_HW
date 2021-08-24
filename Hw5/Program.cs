#nullable enable
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Xml;

//Задания 5-2, 5-3
namespace Hw5
{
    public enum ProgressionType
    {
        Arifmetic,
        Geometric,
        None
    }
    public class Program
    {
        
        public static string GetMinimalString(string instring)
        {
            var t = instring.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList<string>()
                .OrderBy(a => a.Length)
                .FirstOrDefault();

            return string.IsNullOrEmpty(t) ? "" : t;
        }

        public static string[] GetAllMaxStrings(string instring)
        {
            var t = instring.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList<string>().Distinct().OrderBy(a => a.Length).Reverse();
             return t.Where(a => t.First().Length == a.Length).ToArray();
                 
        }
        static void Main(string[] args)
        {
            string testString = "Скажика дядя ведь не даром Москва спаленная пожаром французам отдана";
            Console.WriteLine(GetMinimalString(testString));

            //Первый метод возвращает минимальную строку, знаки припинания не фильтруются - убрал
            Console.WriteLine(GetMinimalString(testString));

            //Второй метод возвращает массив длинных строк
            var ff =
                GetAllMaxStrings(testString);

            Console.WriteLine("Самые длинные строки");
            foreach (var v in ff)
            {
                Console.WriteLine(v);
            }

            //Возврат строки, которая удаляет дублирующие буквы
            Console.WriteLine(StripLine("Скккажжжииииккккка    дяядя ввввведддььь не ДДаром"));
            
            //Метод определяющий прогрессию
            Console.WriteLine(DetectProgression(2,4,8,16,32));
            Console.WriteLine(DetectProgression(2,4,6,10,16));
            Console.WriteLine(DetectProgression(2,4,6,20,16));
            
            //Функция Аккермана
            Console.WriteLine(Accerman(1,1));
            Console.WriteLine(Accerman(1,3));
            Console.WriteLine(Accerman(3,1));
        }

        public static double Accerman(double m, double n)
        {
            if (m == 0) return n + 1;
            if (m > 0 && n ==0) return Accerman(m - 1, 1);
            return Accerman(m - 1, Accerman(m, n - 1));
        }


        public static ProgressionType DetectProgression(params int[] nums)
        {
            if (nums.Length < 2) return ProgressionType.None;

            int arifmeticstep = nums[1] - nums[0];
            float geometricstep = ((float)nums[1]) / nums[0];

            bool isArifmetic = true;
            bool isGeometric = true;

            for (int i = 1; i < nums.Length && (isArifmetic || isGeometric); i++)
            {
                if (nums[i] - nums[i - 1] != arifmeticstep)
                {
                    isArifmetic = false;
                }

                if (nums[i] / nums[i - 1] != geometricstep)
                {
                    isGeometric = false;
                }
            }

            if (isArifmetic) return ProgressionType.Arifmetic;
            if (isGeometric) return ProgressionType.Geometric;
            return ProgressionType.None;
            

        }



        public static string StripLine(string s)
        {
            if (s.Length == 0) throw new Exception("Нулевая строка");
            int sp = 0;
            StringBuilder sb = new StringBuilder(s[sp].ToString());
            for (int i = 1; i <= s.Length; i++)
            {

               // int sp = i - 1;
                if (s[sp] == s[i - 1]) continue;
                sp = i - 1;
                sb.Append(s[sp].ToString());


            }

            return sb.ToString();
        }


    }
}
