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
            _menu.Add(new MenuItem(0, "Список встреч", OpenScheduleSection));
            _menu.Add(new MenuItem(1, "Добавить встречу", OpenEditSection));
            _menu.Add(new MenuItem(2, "Экспортировать в файл", OpenExportSection));
        }

        private void OpenScheduleSection()
        {
            _context.Section = new ScheduleSection();
        }

        private void OpenEditSection()
        {
            _context.Section = new EditSection(new Meeting());
        }
        
        private void OpenExportSection()
        {
            _context.Section = new ExportSection();
        }

        public void Handle(Context context)
        {
            _context = context;
            _menu.Print();
            _context.Request();
        }
    }
}