using System;
using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    public sealed class DetailsSection : ISection
    {
        private readonly Meeting _meeting;
        private Context _context;

        public DetailsSection(Meeting meeting)
        {
            _meeting = meeting;
        }
        
        public void Handle(Context context)
        {
            _context = context;

            var menu = new Menu();
            
            Console.WriteLine(_meeting.Text);
            Console.WriteLine($"Id: {_meeting.Id}");
            Console.WriteLine($"Начало встречи: {_meeting.StartTime:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Окончание встречи: {_meeting.EndTime:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Напомнить за {_meeting.NotificationTime:%m} минут(ы)");
            
            menu.Add(new MenuItem(1, "Удалить встречу", RemoveMeeting));
            menu.Add(new MenuItem(2, "Редактирова встречу", OpenEditSection));
            menu.Add(new MenuItem(3, "К списку встреч", OpenScheduleSection));
            
            menu.Print();
            context.Request();
        }

        private void RemoveMeeting()
        {
            _context.MeetingService.Remove(_meeting);
            OpenScheduleSection();
        }

        private void OpenScheduleSection()
        {
            _context.Section = new ScheduleSection();
        }
        
        private void OpenEditSection()
        {
            _context.Section = new EditSection(_meeting);
        }
    }
}