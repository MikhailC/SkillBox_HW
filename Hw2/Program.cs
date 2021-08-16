using System;
using System.Collections.Generic;
using System.Linq;

namespace Hw2
{
    class Program
    {   
        static List<Employee> Employees = new List<Employee>();
        
        public static void PrintCentered(string smth)
        {
            Console.SetCursorPosition((Console.WindowWidth-smth.Length)/2, Console.CursorTop);
            Console.WriteLine(smth);
        }
        
        static void Main(string[] args)
        {
            PrintCentered("Get me $150 :)");
            for (int i = 0; i < 3; i++)
            {
                Employee emp = new Employee();
                
                Console.WriteLine("Ваше имя");
                emp.Name = Console.ReadLine();
                /* Для красоты будем вызывать функцию, которая умеет и выводить приглашение,
                 и проверять проблемные ввод.*/
                emp.Age = Utils.InputValue<float>( "Ваш возраст", 
                                                "Возраста больше 150 лет не бывает, а отрицательного тем более", 
                                                     x=>x<150&&x>0);
                 
                emp.Height = Utils.InputValue<float>("Ваш рост (метры)",
                                                    "Рост не может быть больше 3х метров (вдруг Вы такой) и должен быть больше нуля ",
                                                    x=>x>0&&x<=3);
                
                /*Возьмем классическую оценку школы от 1 до 5
                  Т.к. в задании сказано что должен быть целый тип, то берем минимально возможный Byte 
                  */
                emp.RussianPoints = Utils.InputValue<byte>("Ваша оценка по русскому языку",
                                                        "Оценка должна быть от 1 до 5, только целая", 
                                                        x=>x>0&&x<=5);
                emp.HistoryPoints = Utils.InputValue<byte>("Ваша оценка по истории",
                                                        "Оценка должна быть от 1 до 5, только целая", 
                                                        x=>x>0&&x<=5);
                emp.MathPoints = Utils.InputValue<byte>("Ваша оценка по математике",
                                                        "Оценка должна быть от 1 до 5, только целая", 
                                                        x=>x>0&&x<=5);
                                                    
                //Будем вызывать разные методы вывода строк при вводе, чтобы удовлетворить всех клиентов )
                if(i==0) 
                    Console.WriteLine(emp);
                if(i==1) 
                    Console.WriteLine("Имя {0} Возраст {1} Рост {2} Рус яз {3} История {4} Метематика {5} Средняя {6}",
                    emp.Name,
                    emp.Age,
                    emp.Height, 
                    emp.RussianPoints, 
                    emp.HistoryPoints, 
                    emp.MathPoints, 
                    emp.AveragePoints);
                if (i == 2)
                    Console.WriteLine("Имя "+ emp.Name+
                                      " Возраст "+emp.Age+
                                      " Рост "+emp.Height+
                                      " Рус яз "+ emp.RussianPoints+
                                      " История "+emp.HistoryPoints+
                                      " Метематика"+emp.MathPoints+
                                      " Средняя "+emp.AveragePoints);
                
                Employees.Add(emp);
            }


        }
    }
}