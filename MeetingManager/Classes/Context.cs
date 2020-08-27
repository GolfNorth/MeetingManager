using System.Collections.Generic;
using MeetingManager.Interfaces;

namespace MeetingManager.Classes
{
    public sealed class Context
    {
        private List<Meeting> Meetings { get; set; }

        public int MeetingId { get; set; }

        public Meeting Meeting
        {
            get => Meetings[MeetingId];
            set => Meetings[MeetingId] = value;
        }
        
        public ISection Section { get; set; }

        public Context(ISection section)
        {
            Meetings = new List<Meeting>();
            Section = section;
        }
        
        public void Request()
        {
            Section.Handle(this);
        }
    }
}