using MeetingManager.Classes;

namespace MeetingManager.Interfaces
{
    /// <summary>
    /// Секция меню
    /// </summary>
    public interface ISection
    {
        /// <summary>
        /// Метод обработки секции
        /// </summary>
        /// <param name="context">Контекст приложения</param>
        void Handle(Context context);
    }
}