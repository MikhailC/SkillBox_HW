using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Hw3;

namespace Hw8
{
    class Program
    {
        

        
        private static Department CurentDepartament;
        
        static void Main(string[] args)
        {
            Corporation corporation = new Corporation();

            Menu.Init
                .Add('1', new CreateNewDepartmentCommand(corporation))
                .Add('2', new SetCurrentDepartmentCommand(corporation))
                .AddSpace()
                .Add('3', new AddNewEmployeeCommand(corporation))
                .Add('4', new EditEmployeeCommand(corporation))
                .Add('5', new DeleteEmpoyeeFromDepartamentCommand(corporation))
                .Add('6', new MultiCommand(1){new ShowEmployeesList(corporation),new SortEmployesByField(corporation), new ShowEmployeesList(corporation)})
                .Add('7', new ShowEmployeesList(corporation))
                .AddSpace()
                .Add('8', new SaveCorporationCommand(corporation))
                .Add('9', new RestoreCorporationCommand(corporation))
                .Show()
                .Play();

            Console.ReadLine();
            MenuItem menu1 = new MenuItem() {Title = "Main menu"};
            menu1.CreateParent("Second");

            for (int i = 0; i < 15; i++)
            {
                menu1.CreateParent($"S{i}");
                
            }
            
            menu1.Action.Invoke();

            Console.ReadLine();
            
         



        }

   

    }


}