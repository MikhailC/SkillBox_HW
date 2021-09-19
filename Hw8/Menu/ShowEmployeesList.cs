using System;

namespace Hw8
{
    public class ShowEmployeesList:IMenuCommand
    {
        private readonly Corporation _corporation;
        public string Title => "Показать список сотрудников";

        public void Execute()
        {
            Console.WriteLine(_corporation.CurrentDepartment.Employees);
        }

        public ShowEmployeesList(Corporation corporation)
        {
            _corporation = corporation;
        }
    }
}