using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingManager.Classes
{
    /// <summary>
    /// Класс меню
    /// </summary>
    public sealed class Menu
    {
        private List<MenuItem> _menuItems;

        public Menu()
        {
            Console.Clear();
            _menuItems = new List<MenuItem>();
        }

        /// <summary>
        /// Добавление пункта меню
        /// </summary>
        /// <param name="menuItem">Объект пункта меню</param>
        public void Add(MenuItem menuItem)
        {
            if (_menuItems.Contains(menuItem)) return;
            
            _menuItems.Add(menuItem);
        }

        /// <summary>
        /// Удаление пункта меню
        /// </summary>
        /// <param name="menuItem">Пункт меню</param>
        public void Remove(MenuItem menuItem)
        {
            if (!_menuItems.Contains(menuItem)) return;
            
            _menuItems.Remove(menuItem);
        }

        /// <summary>
        /// Метод вывода меню и обработки выбора
        /// </summary>
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
            
            sortedMenu[choice - 1].Action?.Invoke();
        }
    }
}