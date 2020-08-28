using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    public sealed class MainSection : ISection
    {
        private readonly Menu _menu;
        private Context _context;

        public MainSection()
        {
            _menu = new Menu();
            _menu.Add(new MenuItem(0, "Список встреч", OpenSchedule));
            _menu.Add(new MenuItem(1, "Добавить встречу", AddMeeting));
            _menu.Add(new MenuItem(2, "Экспортировать в файл", ExportToFile));
        }

        private void OpenSchedule()
        {
            _context.Section = new ScheduleSection();
        }

        private void AddMeeting()
        {
            _context.Section = new EditSection();
        }
        
        private void ExportToFile()
        {
            _context.Section = new ExportSection();
        }

        public void Handle(Context context)
        {
            _context = context;
            _menu.Print();
        }
    }
}