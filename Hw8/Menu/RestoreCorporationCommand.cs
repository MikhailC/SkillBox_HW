using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Hw8
{
    internal class RestoreCorporationCommand : IMenuCommand
    {
        private readonly Corporation _corporation;

        public RestoreCorporationCommand(Corporation corporation)
        {
            _corporation = corporation;
           
        }

        public string Title => "Ввостановить организацию из corp.json";

        public void Execute()
        {
            using TextReader reader = new StreamReader("corp.json");
            _corporation.Departments.Clear();
            List<Department> departments = JsonConvert.DeserializeObject<List<Department>>(reader.ReadToEnd());
            //Надо бы foreach, конечно )
                _corporation.Departments = departments;
                _corporation.CurrentDepartment = departments.Last();
                Console.WriteLine("Восстановлено");
                Console.WriteLine($"Департамент установлен текущим: {_corporation.CurrentDepartment }");

        }
    }
}