using MeetingManager.Classes;
using MeetingManager.Interfaces;

namespace MeetingManager.Sections
{
    /// <summary>
    /// Секция главного экрана
    /// </summary>
    public sealed class MainSection : ISection
    {
        private readonly Menu _menu;
        private Context _context;

        /// <summary>
        /// Секция главного экрана
        /// </summary>
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
            _context.Request();
        }

        private void OpenEditSection()
        {
            _context.Section = new EditSection(new Meeting());
            _context.Request();
        }
        
        private void OpenExportSection()
        {
            _context.Section = new ExportSection();
            _context.Request();
        }

        public void Handle(Context context)
        {
            _context = context;
            _menu.Print();
        }
    }
}