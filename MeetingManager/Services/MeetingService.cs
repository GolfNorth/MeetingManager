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
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _items;
        }

        public Meeting GetById(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
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

        public Meeting Remove(int id)
        {
            var item = GetById(id);

            if (item != null)
                _items.Remove(item);

            return item;
        }
    }
}