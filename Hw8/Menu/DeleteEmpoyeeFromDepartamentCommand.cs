using System;
using Hw3;

namespace Hw8
{
    public class DeleteEmpoyeeFromDepartamentCommand:IMenuCommand
    {
        private readonly Corporation _corporation;
        private readonly Department _department;
        public string Title => "Удалить сотрудника из департамента";

        public void Execute()
        {
            Console.WriteLine("Введите номер сотрудника для удаления:");
            for (int i = 0; i < _department.Employees.Count; i++)
            {
                Console.WriteLine($"{i+1} {_corporation.CurrentDepartment.Employees[i]}");
            }

            int deleteIndex = Utils.InputValue<int>("0 - не удалять ничего, введите номер сотрудника",
                x => x > 0 && x < _department.Employees.Count);
            
            if(deleteIndex>0)
                _department.Employees.RemoveAt(deleteIndex);
        }

        public DeleteEmpoyeeFromDepartamentCommand(Corporation corporation)
        {
            _corporation = corporation;
            _department = corporation.CurrentDepartment;
        }
    }
}