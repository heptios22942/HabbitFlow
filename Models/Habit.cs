// Models/Habit.cs
using HabbitFlow.Models.Enums;
using System;

namespace HabbitFlow.Models
{
    /// <summary>
    /// Конкретная привычка, принадлежащая группе.
    /// </summary>
    public class Habit
    {
        public int Id { get; set; }
        public int GroupId { get; set; }                             // Связь с группой
        public string Name { get; set; } = string.Empty;             // Название привычки
        public HabitType Type { get; set; } = HabitType.Good;        // Тип: хорошая/плохая
        public string Plan { get; set; } = "Мой план действия...";   // План действий
        public TimeSpan ReminderTime { get; set; } = new(9, 0, 0);   // Время напоминания
        public int? DurationMinutes { get; set; } = null;            // Длительность (мин), null = без времени
        public bool IsSpecialCancelable { get; set; } = false;       // «Особо отменяемая» → повторное напоминание через 5 мин
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}