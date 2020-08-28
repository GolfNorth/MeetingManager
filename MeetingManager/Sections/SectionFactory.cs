using MeetingManager.Classes;

namespace MeetingManager.Sections
{
    /// <summary>
    /// Фейковая фабрика секций меню
    /// </summary>
    public static class SectionFactory
    {
        private static MainSection _mainSection;
        private static ScheduleSection _scheduleSection;
        private static ExportSection _exportSection;

        public static MainSection MainSection()
        {
            return _mainSection ?? (_mainSection = new MainSection());
        }
        
        public static ScheduleSection ScheduleSection()
        {
            return _scheduleSection ?? (_scheduleSection = new ScheduleSection());
        }
        
        public static ExportSection ExportSection()
        {
            return _exportSection ?? (_exportSection = new ExportSection());
        }
        
        public static DetailsSection DetailsSection(Meeting meeting)
        {
            return new DetailsSection(meeting);
        }
        
        public static EditSection EditSection(Meeting meeting)
        {
            return new EditSection(meeting);
        }
    }
}