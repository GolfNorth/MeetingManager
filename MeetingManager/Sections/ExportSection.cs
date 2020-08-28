using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    /// <summary>
    /// Секция экспорта встреч в файл
    /// </summary>
    public sealed class ExportSection : ISection
    {
        private Context _context;
        
        public void Handle(Context context)
        {
            _context = context;
            var meetingService = context.MeetingService;
            var pattern = "dd.MM.yyyy";
            var menu = new Menu();
            DateTime date;
            
            do
            {
                Console.Write("Введите дату для экспорта (дд.мм.гггг): ");
            } while (!DateTime.TryParseExact(Console.ReadLine(), pattern, null, DateTimeStyles.None,
                out date));

            var meetings = meetingService.GetAll(date);
            
            foreach (var meeting in meetings)
            {
                Console.WriteLine($"{meeting.StartTime:dd.MM.yyyy HH:mm} - {meeting.EndTime:dd.MM.yyyy HH:mm}\n{meeting.Text}");
            }
            
            menu.Add(new MenuItem(0, "Выбрать другую дату", () => { context.Request();}));
            menu.Add(new MenuItem(1, "Экспортировать в файл", () => { ExportToFile(date, meetings); }));
            menu.Add(new MenuItem(2, "Главное меню", OpenMainSection));
            
            menu.Print();
        }

        private void ExportToFile(DateTime date, IEnumerable<Meeting> meetings)
        {
            var fileName = _context.ExportService.ExportToFile(date, meetings);
            
            _context.Section = new MainSection();
            
            Process.Start(fileName);
            
            Console.WriteLine($"Файл {fileName} успешно создан");
            Console.ReadKey();

            OpenMainSection();
        }
        
        private void OpenMainSection()
        {
            _context.Section = SectionFactory.MainSection();
            _context.Request();
        }
    }
}