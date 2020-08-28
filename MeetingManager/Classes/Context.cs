using MeetingManager.Interfaces;
using MeetingManager.Services;

namespace MeetingManager.Classes
{
    /// <summary>
    /// Класс основного контекста приложения
    /// </summary>
    public sealed class Context
    {
        public ExportService ExportService { get; private set; }
        public MeetingService MeetingService { get; private set; }
        public NotificationService NotificationService { get; private set; }
        public ISection Section { get; set; }

        /// <summary>
        /// Конструктор контекста
        /// </summary>
        /// <param name="section">Секция меню при построении контекста</param>
        public Context(ISection section)
        {
            Section = section;
            ExportService = new ExportService();
            MeetingService = new MeetingService();
            NotificationService = new NotificationService();
        }
        
        /// <summary>
        /// Запуск установленной секции меню
        /// </summary>
        public void Request()
        {
            Section.Handle(this);
        }
    }
}