using System;

namespace Hw8
{
    public class AddNewEmployeeCommand:IMenuCommand
    {
        private readonly Corporation _corporation;
        public string Title => "Добавить нового сотрудника";

        public void Execute()
        {
            Console.WriteLine($"Добавление сотрудника в департамент {_corporation.CurrentDepartment}");
            
            Employee employee = new Employee() {Department = _corporation.CurrentDepartment};
            _corporation.CurrentDepartment.Employees.Add(employee);
            employee.Edit();
            
           // _corporation.CurrentDepartment
        }

        public AddNewEmployeeCommand(Corporation corporation)
        {
            _corporation = corporation;
        }
    }
}