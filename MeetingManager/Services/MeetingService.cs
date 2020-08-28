using System;
using System.Collections.Generic;
using System.Linq;
using MeetingManager.Classes;

namespace MeetingManager.Services
{
    /// <summary>
    /// Сервис хранилища встреч
    /// </summary>
    public sealed class MeetingService
    {
        private readonly List<Meeting> _items;
        
        /// <summary>
        /// Конструктор сервиса хранилища встреч
        /// </summary>
        /// <param name="items">Список встреч при инициализации сервиса</param>
        public MeetingService(List<Meeting> items = null)
        {
            _items = items ?? new List<Meeting>();
        }

        /// <summary>
        /// Метод получения всех встреч
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Meeting> GetAll()
        {
            return _items;
        }
        
        /// <summary>
        /// Метод получения всех встреч по заданной дате
        /// </summary>
        /// <param name="date">Дата встреч</param>
        /// <returns></returns>
        public IEnumerable<Meeting> GetAll(DateTime date)
        {
            return _items.Where(meeting => meeting.StartTime.Year == date.Year && meeting.StartTime.Month == date.Month && meeting.StartTime.Day == date.Day);
        }

        /// <summary>
        /// Метод добавления встречи в хранилище
        /// </summary>
        /// <param name="item">Объект новой встречи</param>
        /// <returns>Id новой встречи</returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Метод удаления встречи из хранилища
        /// </summary>
        /// <param name="meeting">Объект удаляемой встречи</param>
        /// <returns>Успешность удаления встречи</returns>
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