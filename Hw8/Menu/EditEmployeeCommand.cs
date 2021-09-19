using System;
using Hw3;

namespace Hw8
{
    public class EditEmployeeCommand:IMenuCommand

    {
        private readonly Corporation _corporation;
        private readonly Department _department;

        public EditEmployeeCommand(Corporation corporation)
        {
            _corporation = corporation;
            _department = corporation.CurrentDepartment;
        }

        public string Title => "Редактировать сотрудника";

        public void Execute()
        {
            Console.WriteLine("Введите номер сотрудника для редактирования:");
           Console.WriteLine(_department.Employees);

            int editIndex = Utils.InputValue<int>("0 - не редактировать ничего, введите номер сотрудника",
                x => x > 0 && x < _department.Employees.Count);
            
            if(editIndex>0)
                _department.Employees[editIndex].Edit();
        }
    }
}