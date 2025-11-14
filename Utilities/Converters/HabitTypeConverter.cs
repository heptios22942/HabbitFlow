using System;
using System.Globalization;
using System.Windows.Data;
using HabbitFlow.Models.Enums;

namespace HabbitFlow.Utilities.Converters
{
    public class HabitTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HabitType habitType)
            {
                return habitType == HabitType.Good ? "Хорошая привычка" : "Плохая привычка";
            }
            return "Хорошая привычка";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string habitTypeString)
            {
                return habitTypeString == "Хорошая привычка" ? HabitType.Good : HabitType.Bad;
            }
            return HabitType.Good;
        }
    }
}