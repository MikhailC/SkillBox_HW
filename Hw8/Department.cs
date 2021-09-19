using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hw3;

namespace Hw8
{
    public class Department:IComparable<Department>,IComparable
    {
        public string Title { get; set; }
        public DateTime CreationDate { get;
            set;
        }=DateTime.Now;
        
        public readonly EmployeesList Employees = new EmployeesList();
        
        public override string ToString() => $"{Title} (создан {CreationDate} кол-во сотрудников {Employees.Count})";


        #region Реализация CompareTo

        

        public int CompareTo(Department other) => String.Compare(this.Title, other.Title, StringComparison.Ordinal);
        
        public int CompareTo(object? obj) => this.CompareTo((Department) obj);

        #endregion


        public bool Edit()
        {
            Title = Utils.InputValue<string>(errorText: "Название департамента должно быть не менее двух букв",
                test: x => x.Length >= 2, "Введите название департамента");

            CreationDate = Utils.InputValue<DateTime>("Дата создания должна быть раньше чем сегодня",
                x => x < DateTime.Now, "Введите дату создания");

            return true;

        }
    }

    
}