using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MeetingManager.Classes;

namespace MeetingManager.Services
{
    public sealed class NotificationService
    {
        private readonly Dictionary<Meeting, CancellationTokenSource> _cancellationTokens;

        public NotificationService()
        {
            _cancellationTokens = new Dictionary<Meeting, CancellationTokenSource>();
        }

        public void Add(Meeting meeting)
        {
            if (_cancellationTokens.ContainsKey(meeting))
                Remove(meeting);
            
            var notificationTime = meeting.StartTime - meeting.NotificationTime;
            
            if (notificationTime < DateTime.Now) return;
            
            var source = new CancellationTokenSource();
            var delay = notificationTime - DateTime.Now;
            
            Console.WriteLine(notificationTime);
            Console.WriteLine(delay);

            Task.Run(async delegate
            {
                await Task.Delay(delay, source.Token);
                Console.WriteLine("\nВнимание!");
                Console.WriteLine($"{meeting.Text} начнется в {meeting.StartTime:HH:mm}\n");
            }, source.Token);
            
            _cancellationTokens.Add(meeting, source);
        }

        public void Remove(Meeting meeting)
        {
            if (!_cancellationTokens.ContainsKey(meeting)) return;
            
            _cancellationTokens[meeting].Cancel();
            _cancellationTokens.Remove(meeting);
        }
    }
}