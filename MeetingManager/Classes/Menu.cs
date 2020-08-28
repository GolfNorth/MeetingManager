using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingManager.Classes
{
    public sealed class Menu
    {
        private List<MenuItem> _menuItems;

        public Menu()
        {
            _menuItems = new List<MenuItem>();
        }

        public void Add(MenuItem menuItem)
        {
            if (_menuItems.Contains(menuItem)) return;
            
            _menuItems.Add(menuItem);
        }

        public void Remove(MenuItem menuItem)
        {
            if (!_menuItems.Contains(menuItem)) return;
            
            _menuItems.Remove(menuItem);
        }

        public void Print()
        {
            var sortedMenu = _menuItems.OrderBy(item => item.Order).ToArray();

            for (var i = 0; i < sortedMenu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedMenu[i].Text}");
            }
            
            var choice = 0;

            while (choice <= 0 || choice > sortedMenu.Length)
            {
                int.TryParse(Console.ReadLine(), out choice);
            }
            
            sortedMenu[choice - 1].Action.Invoke();
        }
    }
}