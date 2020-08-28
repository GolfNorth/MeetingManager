using System;
using System.Collections.Generic;
using System.Linq;
using MeetingManager.Classes;

namespace MeetingManager.Services
{
    public sealed class MeetingService
    {
        private readonly List<Meeting> _items;
        
        public MeetingService(List<Meeting> items = null)
        {
            _items = items ?? new List<Meeting>();

            for (int i = 0; i < 10; i++)
            {
                var meeting = new Meeting();
                meeting.Text = $"Meeting_{i}";
                Add(meeting);
            }
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _items;
        }

        public int Add(Meeting item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (_items.Contains(item)) return item.Id;

            item.Id = _items.Count == 0
                ? 1
                : _items.Max(r => r.Id) + 1;
            _items.Add(item);

            return item.Id;
        }

        public bool Remove(Meeting meeting)
        {
            return _items.Remove(meeting);
        }

        public bool CheckFreeTime(DateTime startTime, DateTime endTime)
        {
            foreach (var meeting in _items)
            {
                if ((startTime > meeting.StartTime && startTime < meeting.EndTime) ||
                    (endTime > meeting.StartTime && endTime < meeting.EndTime) ||
                    (startTime < meeting.StartTime && endTime > meeting.EndTime))
                    return false;
            }
            
            return true;
        }
    }
}