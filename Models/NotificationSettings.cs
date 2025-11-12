// Models/NotificationSettings.cs
namespace HabbitFlow.Models
{
    /// <summary>
    /// Глобальные настройки уведомлений.
    /// </summary>
    public class NotificationSettings
    {
        public bool EnableMorningSummary { get; set; } = true;       // Утренний список привычек
        public bool EnableEveningAnalysis { get; set; } = true;      // Вечерний анализ
        public bool EnableMotivationalMessages { get; set; } = true; // Мотивационные сообщения
        public int ReminderDelayMinutes { get; set; } = 5;           // Задержка повторного напоминания
    }
}