using System.Linq;
using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
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
                menu.Add(new MenuItem(++order, meeting.Text, () => { OpenDetailsSection(meeting); }));
            }
            
            menu.Add(new MenuItem(++order, "Добавить встречу", OpenEditSection));
            menu.Add(new MenuItem(++order, "Главное меню", OpenMainSection));
            menu.Print();
            
            context.Request();
        }

        private void OpenMainSection()
        {
            _context.Section = new MainSection();
        }
        
        private void OpenEditSection()
        {
            _context.Section = new EditSection(new Meeting());
        }

        private void OpenDetailsSection(Meeting meeting)
        {
            _context.Section = new DetailsSection(meeting);
        }
    }
}