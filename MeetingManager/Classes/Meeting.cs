using System;

namespace MeetingManager.Classes
{
    /// <summary>
    /// Объект встречи
    /// </summary>
    public sealed class Meeting
    {
        /// <summary>
        /// Id встречи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Текст или заголовок встречи
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата начала встречи
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Дата окончания встречи
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Промежуток времени за который нужно уведомить о предстоящей встречи
        /// </summary>
        public TimeSpan NotificationTime { get; set; }
    }
}