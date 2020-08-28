using System;

namespace MeetingManager.Classes
{
    public sealed class Meeting
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan NotificationTime { get; set; }
    }
}