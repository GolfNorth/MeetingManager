using System.Linq;
using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    /// <summary>
    /// Секция расписания встреч
    /// </summary>
    public sealed class ScheduleSection : ISection
    {
        private Context _context;
        
        public void Handle(Context context)
        {
            _context = context;
            var order = 0;
            var menu = new Menu();
            var meetingService = context.MeetingService;

            foreach (var meeting in meetingService.GetAll().OrderBy(meeting => meeting.StartTime))
            {
                var text = $"{meeting.StartTime:dd.MM.yyyy HH:mm} - {meeting.EndTime:dd.MM.yyyy HH:mm}\n{meeting.Text}";
                menu.Add(new MenuItem(++order, text, () => { OpenDetailsSection(meeting); }));
            }
            
            menu.Add(new MenuItem(++order, "Добавить встречу", OpenEditSection));
            menu.Add(new MenuItem(++order, "Главное меню", OpenMainSection));
            menu.Print();
        }

        private void OpenMainSection()
        {
            _context.Section = SectionFactory.MainSection();
            _context.Request();
        }
        
        private void OpenEditSection()
        {
            _context.Section = SectionFactory.EditSection(new Meeting());
            _context.Request();
        }

        private void OpenDetailsSection(Meeting meeting)
        {
            _context.Section = SectionFactory.DetailsSection(meeting);
            _context.Request();
        }
    }
}