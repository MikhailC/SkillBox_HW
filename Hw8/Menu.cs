using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hw8
{
    public class Menu
    {
        private readonly Dictionary<char, IMenuCommand> _menuItems = new Dictionary<char, IMenuCommand>();
        private int lnCnt = 0;

        public Menu Add(char key, IMenuCommand command)
        {
            _menuItems.Add(key,command);
            return this;
        }

        public Menu AddSpace()
        {
            //Вряд ли будет много разделителей
            
            _menuItems.Add((char) lnCnt++,null);
            return this;
        }

        public Menu Show()
        {
            Console.WriteLine("Нажмите клавишу для выбора в меню:");
            foreach (var item in _menuItems)
            {
                if (item.Value is null)
                {
                    Console.WriteLine("------------------------------");
                }
                else
                {
                    Console.WriteLine($"  {item.Key} {item.Value?.Title??"--------------------------------"}");

                }
            }
            
            Console.WriteLine("Для выхода нажмите Esc");

            return this;
        }

        public void Play()
        {
            ConsoleKeyInfo key ;
            while ((key = Console.ReadKey()).Key!= ConsoleKey.Escape)
            {
                if (_menuItems.ContainsKey(key.KeyChar))
                {
                    _menuItems[key.KeyChar].Execute();
                    Console.WriteLine("Нажмиите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    Show();
                }
            }
        }

        public static Menu Init => new Menu();

    }
}