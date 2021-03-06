﻿using System;
using System.Globalization;
using MeetingManager.Classes;
using MeetingManager.Extensions;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    /// <summary>
    /// Секция редактирования встречи
    /// </summary>
    public sealed class EditSection : ISection
    {
        private readonly Meeting _meeting;

        /// <summary>
        /// Секция редактирования встречи
        /// </summary>
        /// <param name="meeting">Объект встречи</param>
        public EditSection(Meeting meeting)
        {
            _meeting = meeting;
        }
        
        public void Handle(Context context)
        {
            var meetingService = context.MeetingService;
            var notificationService = context.NotificationService;
            var pattern = "dd.MM.yyyy HH:mm";
            var notificationTime = -1; 
            var startTime = _meeting.StartTime;
            var endTime = _meeting.EndTime;

            Console.Clear();

            do
            {
                Console.Write("Введите заголовок встречи: ");
                _meeting.Text = ConsoleExtensions.ReadLine(_meeting.Text);
            } while (String.IsNullOrWhiteSpace(_meeting.Text));

            while (true)
            {
                var startTimeText = _meeting.Id == 0 ? "" : $"{startTime:dd.MM.yyyy HH:mm}";
                
                do
                {
                    Console.Write("Введите время и дату начала встречи (дд.мм.гггг чч:мм): ");
                } while (!(DateTime.TryParseExact(ConsoleExtensions.ReadLine(startTimeText), pattern, null, DateTimeStyles.None,
                    out startTime) && startTime > DateTime.Now));

                var endTimeText = _meeting.Id == 0 ? "" : $"{endTime:dd.MM.yyyy HH:mm}";
                
                do
                {
                    Console.Write("Введите время и дату окончания встречи (дд.мм.гггг чч:мм): ");
                } while (!(DateTime.TryParseExact(ConsoleExtensions.ReadLine(endTimeText), pattern, null, DateTimeStyles.None,
                    out endTime) && endTime > startTime));
                
                if (meetingService.CheckFreeTime(_meeting))
                    break;
                
                Console.WriteLine("Время пересекается с другими встречами");
            }

            do
            {
                Console.Write("За сколько минут напомнить о встрече: ");
            } while (!(int.TryParse(Console.ReadLine(), out notificationTime) && notificationTime > -1));

            _meeting.StartTime = startTime;
            _meeting.EndTime = endTime;
            _meeting.NotificationTime = new TimeSpan(0, notificationTime, 0);

            if (_meeting.Id == 0)
                meetingService.Add(_meeting);
            
            notificationService.Add(_meeting);
            
            context.Section = SectionFactory.DetailsSection(_meeting);
            context.Request();
        }
    }
}