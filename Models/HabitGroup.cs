// Models/HabitGroup.cs
using System;
using System.Collections.ObjectModel;

namespace HabbitFlow.Models
{
    /// <summary>
    /// Группа привычек — контейнер для привычек одного направления (например, «Здоровье», «Учёба»).
    /// </summary>
    public class HabitGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Memo { get; set; } = "";
        public bool EnableMotivation { get; set; }
        public DateTime CreatedAt { get; set; }

        // ⚠️ УБЕДИТЕСЬ ЧТО ЕСТЬ ЭТО СВОЙСТВО:
        public ObservableCollection<Habit> Habits { get; set; } = new ObservableCollection<Habit>();

        // ⚠️ ИЛИ ДОБАВЬТЕ СВОЙСТВО ДЛЯ ПОДСЧЕТА:
       
    }
}