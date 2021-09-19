using System;
using System.Linq;

namespace Hw8
{
    public class CreateNewDepartmentCommand:IMenuCommand
    {
        private readonly Corporation _organization;
        public string Title=>"Добавить департамент";

        public void Execute()
        {
            Console.WriteLine("Введите наименование департамента");
           _organization.Departments.Add(new Department {Title = Console.ReadLine()!});
           if (_organization.CurrentDepartment is null)
           {
               _organization.CurrentDepartment = _organization.Departments.Last();
               Console.WriteLine("Департамент установлен текущим");
           }
           
        }

        public CreateNewDepartmentCommand(Corporation organization)
        {
            _organization = organization;
        }
    }
}