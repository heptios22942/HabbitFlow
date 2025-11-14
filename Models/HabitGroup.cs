using System;
using System.Collections.ObjectModel;

namespace HabbitFlow.Models
{
    public class HabitGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Memo { get; set; } = "";
        public string Color { get; set; } = "";
        public bool EnableMotivation { get; set; }
        public DateTime CreatedAt { get; set; }

        // ИСПРАВЛЕННОЕ СВОЙСТВО - должно быть инициализировано
        public ObservableCollection<Habit> Habits { get; set; } = new ObservableCollection<Habit>();

        // Добавляем свойство для подсчета привычек
        public int HabitsCount => Habits.Count;
    }
}