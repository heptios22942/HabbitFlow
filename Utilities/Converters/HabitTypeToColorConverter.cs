


using HabbitFlow.Models.Enums;
// ← ИСПРАВЛЕНО! Было HabbitFlow.Models
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HabbitFlow.Utilities.Converters
{
    public class HabitTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HabitType habitType)
            {
                return habitType switch
                {
                    HabitType.Good => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E8F5E9")),
                    HabitType.Bad => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEBEE")),
                    _ => Brushes.Transparent
                };
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}