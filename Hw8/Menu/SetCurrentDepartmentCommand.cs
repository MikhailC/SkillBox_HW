using System;
using Hw3;

namespace Hw8
{
    public class SetCurrentDepartmentCommand:IMenuCommand
    {
        private readonly Corporation _corporation;
        public string Title => "Установить текущее подразделение";

        public void Execute()
        {
            Console.WriteLine("Введите номер текущего департамента");
            for (int i = 0; i < _corporation.Departments.Count;i++)
            {
                Console.WriteLine($@"{i + 1} {_corporation.Departments[i]}");
            }

            int index = Utils.InputValue<int>($"Необходимо выбрать число от 1 до {_corporation.Departments.Count}",
                x => x > 0 && x <= _corporation.Departments.Count);

            _corporation.CurrentDepartment = _corporation.Departments[index - 1];


        }

        public SetCurrentDepartmentCommand(Corporation corporation)
        {
            _corporation = corporation;
        }
        
    }
}