// Models/HabitExecution.cs
using System;

namespace HabbitFlow.Models
{
    /// <summary>
    /// Результат выполнения привычки за конкретный день.
    /// </summary>
    public class HabitExecution
    {
        public int Id { get; set; }
        public int HabitId { get; set; }                             // Связь с привычкой
        public DateTime ExecutionDate { get; set; } = DateTime.Today; // Дата выполнения

        // Для полезных привычек
        public bool IsCompleted { get; set; } = true;                // Выполнил (true) / Не сделал (false)

        // Оценка выполнения (1–5), null = не оценивалось
        public int? Rating { get; set; } = null;

        // Что понравилось / ощущения
        public string Feedback { get; set; } = string.Empty;

        // Для срывов (плохие привычки или пропуск)
        public bool IsRelapse { get; set; } = false;                 // true = поддался вредной привычке
        public string Reason { get; set; } = string.Empty;           // Причина срыва (≥50 символов)

        // Метки для аналитики
        public bool IsSecondAttempt { get; set; } = false;           // Повторная попытка (через 5 мин)
    }
}