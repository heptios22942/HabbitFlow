using HabbitFlow.Models;
using HabbitFlow.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HabbitFlow.ViewModels.Habits
{
    public class HabitGroupEditorViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVm;

        private string _name = "";
        private string _icon = "📚";
        private string _memo = "Моя памятка...";
        private string _color = "#4CAF50";
        private bool _enableMotivation = true;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Icon { get => _icon; set { _icon = value; OnPropertyChanged(); } }
        public string Memo { get => _memo; set { _memo = value; OnPropertyChanged(); } }
        public string Color { get => _color; set { _color = value; OnPropertyChanged(); } }
        public bool EnableMotivation { get => _enableMotivation; set { _enableMotivation = value; OnPropertyChanged(); } }

        // Коллекция доступных иконок
        public ObservableCollection<string> AvailableIcons { get; } = new()
        {
            "📚", "🏃", "🧘", "💪", "🏋️", "🚴", "🎯", "⭐", "🔥", "💡",
            "📖", "✏️", "🎨", "🎵", "🏠", "🍎", "💧", "😴", "🌞", "🌙",
            "❤️", "💰", "🚀", "🎪", "🏆", "📊", "🔔", "⏰", "✅", "📝",
            "🎮", "👨‍💻", "👩‍🍳", "🚶", "🧠", "💼", "🛌", "🚿", "🍽️", "☕"
        };

        // Коллекция доступных цветов
        public ObservableCollection<string> AvailableColors { get; } = new()
{
    // Зеленые оттенки
   "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107",
    "#FF9800", "#FF5722", "#795548", "#9E9E9E", "#607D8B",
    
    // Холодные тона
    "#2196F3", "#03A9F4", "#00BCD4", "#009688", "#4CAF50",
    "#3F51B5", "#673AB7", "#9C27B0", "#E91E63", "#F44336",
    
    // Пастельные тона
    "#E8F5E8", "#E3F2FD", "#F3E5F5", "#FFF3E0", "#E0F2F1",
    "#FCE4EC", "#F1F8E9", "#FFF8E1", "#E8EAF6", "#E0F7FA",
    
    // Яркие акцентные
    "#FF4081", "#E040FB", "#7C4DFF", "#536DFE", "#448AFF",
    "#40C4FF", "#18FFFF", "#64FFDA", "#69F0AE", "#B2FF59",
    
    // Глубокие насыщенные
    "#D32F2F", "#C2185B", "#7B1FA2", "#512DA8", "#303F9F",
    "#1976D2", "#0288D1", "#0097A7", "#00796B", "#388E3C",
    
    // Нейтральные
    "#616161", "#424242", "#212121", "#757575", "#9E9E9E",
    "#BDBDBD", "#E0E0E0", "#EEEEEE", "#F5F5F5", "#FAFAFA",
    
    // Теплые землистые
    "#5D4037", "#6D4C41", "#8D6E63", "#A1887F", "#BCAAA4",
    "#FFAB91", "#FFCCBC", "#D7CCC8", "#BCAAA4", "#8D6E63",
    
    // Сочные фруктовые
    "#FF8A65", "#FF7043", "#F4511E", "#D84315", "#BF360C",
    "#FFB74D", "#FFA726", "#FF9800", "#FB8C00", "#F57C00"
};

        public ICommand SaveCommand { get; }
        public ICommand GoBackCommand { get; }

        public HabitGroupEditorViewModel(MainViewModel mainVm)
        {
            _mainVm = mainVm;
            SaveCommand = new RelayCommand(_ => Save());
            GoBackCommand = new RelayCommand(_ => _mainVm.NavigateToHabitGroups());
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Name)) return;
            _mainVm.AddHabitGroup(Name, Icon, Memo, EnableMotivation, Color);
            _mainVm.NavigateToHabitGroups();
        }
    }
}