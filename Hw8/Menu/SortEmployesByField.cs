using System;
using System.Collections.Generic;
using System.Linq;

namespace Hw8
{
    
    public class SortEmployesByField:IMenuCommand
    {
        private readonly Corporation _corporation;
        //private readonly Department _department;

        public SortEmployesByField(Corporation corporation)
        {
            _corporation = corporation;
            
        }

        public string Title => "Сортировать сотрудников по произвольному полю";

        public void Execute()
        {
            Dictionary<string, string> flds = Employee.FieldsInfo;
            int i = 1;
            foreach (var field in flds)
            {
             
                    Console.WriteLine($"{i++} {field.Value}");
            }
            Console.WriteLine("Сортировка сотрудников текущего департамента по перечисленным полям");
            Console.WriteLine("Введите через запятую номера полей для сортировки");
            string fldnums = Console.ReadLine();
            var keys = flds.Keys.ToArray();
            List<string> tgt = new List<string>();
            foreach (var num in fldnums.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                tgt.Add(keys[int.Parse(num)-1]);
            }
            
            _corporation.CurrentDepartment.Employees.OrderByMultuplyFields(tgt.ToArray());
        }
    }
}