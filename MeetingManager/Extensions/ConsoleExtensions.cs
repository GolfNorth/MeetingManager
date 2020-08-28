using System;
using System.Collections.Generic;

namespace MeetingManager.Extensions
{
    /// <summary>
    /// Расширение возможностей консоли
    /// </summary>
    public static class ConsoleExtensions
    {
        /// <summary>
        /// Чтение консоли с функцией редактирования заданного текста
        /// </summary>
        /// <param name="text">Заданный текст</param>
        /// <returns></returns>
        public static string ReadLine(string text)
        {
            var position = Console.CursorLeft;

            Console.Write(text);

            var chars = new List<char>();

            if (string.IsNullOrEmpty(text) == false)
                chars.AddRange(text.ToCharArray());

            while (true)
            {
                var info = Console.ReadKey(true);
                
                if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > position)
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.CursorLeft--;
                    Console.Write(' ');
                    Console.CursorLeft--;
                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    Console.Write(Environment.NewLine);
                    break;
                }
                else if (char.IsPunctuation(info.KeyChar) || char.IsLetterOrDigit(info.KeyChar) ||
                         char.IsWhiteSpace(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);
                }
            }

            return new string(chars.ToArray());
        }
    }
}