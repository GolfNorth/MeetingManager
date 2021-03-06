﻿using System;
using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    /// <summary>
    /// Секция подробной информации о встрече
    /// </summary>
    public sealed class DetailsSection : ISection
    {
        private readonly Meeting _meeting;
        private Context _context;

        /// <summary>
        /// Секция подробной информации о встрече
        /// </summary>
        /// <param name="meeting">Объект встречи</param>
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
        }
        
        private void RemoveMeeting()
        {
            _context.MeetingService.Remove(_meeting);
            _context.NotificationService.Remove(_meeting);
            OpenScheduleSection();
        }

        private void OpenScheduleSection()
        {
            _context.Section = SectionFactory.ScheduleSection();
            _context.Request();
        }
        
        private void OpenEditSection()
        {
            _context.Section = SectionFactory.EditSection(_meeting);
            _context.Request();
        }
    }
}