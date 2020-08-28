using MeetingManager.Interfaces;
using MeetingManager.Services;

namespace MeetingManager.Classes
{
    public sealed class Context
    {
        public ExportService ExportService { get; private set; }
        public MeetingService MeetingService { get; private set; }
        public NotificationService NotificationService { get; private set; }
        public ISection Section { get; set; }

        public Context(ISection section)
        {
            Section = section;
            ExportService = new ExportService();
            MeetingService = new MeetingService();
            NotificationService = new NotificationService();
        }
        
        public void Request()
        {
            Section.Handle(this);
        }
    }
}