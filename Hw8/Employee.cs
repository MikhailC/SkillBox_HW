using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Hw8.Helpers;
using Microsoft.VisualBasic.CompilerServices;
using Utils = Hw3.Utils;

namespace Hw8
{
    public class Employee
    {
        private Department _department;
    
        [ConsoleCaption("Имя")]
        public string FirstName { get; set; }
        [ConsoleCaption("Фамилия")]
        public string LastName { get; set; }
        [ConsoleCaption("Возраст")]
        public int Age { get; set; }

        public Department Department
        {
            get => _department;
            set
            {
                if (value == _department) return;
                _department?.Employees.Remove(this);
                _department = value;
                //_department?.Employees.Add(this);
            }
        }

        //[DisplayName("Индентификатор")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ConsoleCaption("Зарплата")] 
        public float Salary { get; set; } = 0;
        
        [ConsoleCaption("Телефон")]
        public string Phone { get; set; }
        
        public object this[string propertyName]
        {
            get
            {
                PropertyInfo info = this.GetType().GetProperty(propertyName);
                return info?.GetValue(this, null);
            } set
            {
                PropertyInfo? info = this.GetType().GetProperty(propertyName);
                info?.SetValue(this, value, null);
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Возраст {Age} Департамент {Department.Title} Зарплата {Salary} Телефон {Phone}id: {Id}";
        }


        public void Edit()
        {
            Console.WriteLine($"Введите имя, для текущего значения {FirstName??"<не задано>"} нажмите Enter");
            string firstName = Console.ReadLine();
            if (firstName.Length!=0)
            {
                FirstName = firstName;
            }

            Console.WriteLine($"Введите фамилию, для текущего значения {LastName??"<не задано>"} нажмите Enter");

            string lastName = Console.ReadLine();
            if (lastName.Length != 0)
            {
                LastName = lastName;
            }

            int age = Utils.InputValue<int>(
                "Укажите параметр -1 для того чтобы оставить текущее значение, либо любое число от 0 и выше для задания возраста ",
                x => x > -1, $"Введите количество лет. -1 для значения {Age}");

            if (age != -1)
            {
                Age = age;
                
            }

            float salary = Utils.InputValue<float>(
                "Укажите -1 для значения по умолчанию, либо любое число больше или равное 0",
                x => x > -1, $"Укажите размер зарплаты, -1 для значения {Salary}");
            if ((salary >= 0))
            {
                Salary = salary;
            }
            
            Console.WriteLine($"Введите номер телефона, Enter для значения {Phone??"<не задан>"}");
            string phone = Console.ReadLine();
            if (phone.Length != 0)
            {
                Phone = phone;
            }


            /*         foreach (var v1 in TypeDescriptor.GetProperties(typeof(Employee))
                         .Cast<PropertyDescriptor>()
                         .Where(p=>p.Attributes != null && ((ConsoleCaptionAttribute)p.Attributes[typeof(ConsoleCaptionAttribute)]).Editable))
                     {
                         Console.WriteLine(v1.Attributes[typeof(ConsoleCaptionAttribute)].);
                     }
                     
                     foreach (var v in FieldsInfo)
                     {
                         Console.WriteLine($"{v.Value} = {this[v.Key] ?? "<NA>"}");
                         var pinfo = typeof(Employee).GetProperties()
                             .Where(a => a.Name.Equals(v.Value))
                             .FirstOrDefault();
         
                         Console.WriteLine($"Введите {v.Key}. Enter для значения {this[v.Value]}");
                         string str = Console.ReadLine();
                         if (str is not null && str.Length != 0)
                         {
                            this[v.Value] = TypeDescriptor.GetConverter(pinfo!.PropertyType).ConvertFromString(str);
         
         
                         }
         
                     //Console.WriteLine(pinfo!.PropertyType);
                     }*/
        }

        public static Dictionary<string, string> FieldsInfo =>
            TypeDescriptor.GetProperties(typeof(Employee))
                .Cast<PropertyDescriptor>()
                .Where(p => p.Attributes[typeof(ConsoleCaptionAttribute)] is not null)
                .ToDictionary(p => p.Name,
                    p => ((ConsoleCaptionAttribute) p.Attributes[typeof(ConsoleCaptionAttribute)]).DisplayName);
    }
}