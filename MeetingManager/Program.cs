using MeetingManager.Classes;
using MeetingManager.Sections;

namespace MeetingManager
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var context = new Context(new MainSection());
            context.Request();
        }
    }
}