using System;

namespace MeetingManager.Classes
{
    /// <summary>
    /// Объект пункта меню
    /// </summary>
    public sealed class MenuItem
    {
        /// <summary>
        /// Очередность
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Действие при выборе
        /// </summary>
        public Action Action { get; set; }

        public MenuItem()
        {
            
        }
        
        /// <summary>
        /// Пункт меню
        /// </summary>
        /// <param name="order">Очередность</param>
        /// <param name="text">Текст</param>
        /// <param name="action">Действие при выборе</param>
        public MenuItem(int order, string text, Action action)
        {
            Order = order;
            Text = text;
            Action = action;
        }
    }
}