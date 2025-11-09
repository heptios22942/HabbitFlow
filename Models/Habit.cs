using HabbitFlow.Models.Enums;
using System.Windows.Media;

namespace HabitTracker.Models
{
    
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HabitType type { get; set; }
        public TimeSpan? Time { get; set; }
        public string ActionPlan { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }

        // Цвет привычки (пользователь выбирает)
        public string ColorHex { get; set; } = "#E8F5E9"; // Цвет по умолчанию

        // Свойство для WPF привязки
        public Brush ColorBrush => new SolidColorBrush(
            (Color)ColorConverter.ConvertFromString(ColorHex ?? "#E8F5E9"));

        public string StatusColor => IsCompleted ? "#FF4CAF50" : "#FFF5F5F5";
    }
}