using HabbitFlow.Models.Enums;
using System.Globalization;
using System.Windows.Data;

namespace HabbitFlow.Utilities.Converters
{
    public class HabbitTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HabitType habitType)
            {
                return habitType switch
                {
                    HabitType.Good => "Хорошая привычка",
                    HabitType.Bad => "Плохая привычка",
                    _ => "Неизвестно"
                };
            }
            return "Неизвестно";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return str switch
                {
                    "Хорошая привычка" => HabitType.Good,
                    "Плохая привычка" => HabitType.Bad,
                    _ => HabitType.Good
                };
            }
            return HabitType.Good;
        }
    }
}
