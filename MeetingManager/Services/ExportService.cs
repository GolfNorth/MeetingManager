using System;
using System.Collections.Generic;
using System.IO;
using MeetingManager.Classes;

namespace MeetingManager.Services
{
    public sealed class ExportService
    {
        public string ExportToFile(DateTime date, IEnumerable<Meeting> meetings)
        {
            var fileName = $"Meetings_{date:dd.MM.yyyy}.txt";
            
            using (var outputFile = new StreamWriter(fileName))
            {
                foreach (var meeting in meetings)
                {
                    outputFile.WriteLine(meeting.Text);
                    outputFile.WriteLine($"Начало встречи: {meeting.StartTime:dd.MM.yyyy HH:mm}");
                    outputFile.WriteLine($"Окончание встречи: {meeting.EndTime:dd.MM.yyyy HH:mm}");
                }
            }

            return fileName;
        }
    }
}