using System;

namespace MeetingManager.Classes
{
    public sealed class MenuItem
    {
        public int Order { get; set; }
        public string Text { get; set; }
        public Action Action { get; set; }

        public MenuItem()
        {
            
        }
        
        public MenuItem(int order, string text, Action action)
        {
            Order = order;
            Text = text;
            Action = action;
        }
    }
}