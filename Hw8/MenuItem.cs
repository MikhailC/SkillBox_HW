using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic.CompilerServices;

namespace Hw8
{
    public class MenuItem
    {
        
        public string Title { get; set; }
        public char Key { get; set; }

        private MenuItem _parent;

        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public Action Action => () =>
        {
            if (_parent is null)
            {
                Console.WriteLine($"|{Title}");

            }
            else
            {
                Console.WriteLine($"|{Title}. Нажмите кнопку Back для возврата");
            }

            foreach (var item in Items)
            {
                Console.WriteLine($"|--- {item.Key} {item.Title}");
            }
        };



        public MenuItem CreateParent(string title)
        {
            char Key = default(char);
 
            if (Items.Count <= 9)
            {
                Key = (char) (Items.Count + '0');
            }
            else if (Items.Count > 9 && Items.Count <= 28)
            {
                Key = (char) (Items.Count-9 + 'A');
            }
            else
            {
                throw new Exception("меню больше 38 пунктов не поддерживается");
            }
   

            MenuItem i=new MenuItem
            {
                Title = title,
                _parent = this,
                Key=Key
            };
            Items.Add(i);

            return i;
        }


    }
}