using HabbitFlow.Views.Auth;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
// Добавьте это в самый верх файла, перед всеми using
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;
using INavigationService = HabbitFlow.Utilities.INavigationService;


using HabbitFlow.Utilities;

namespace HabbitFlow.ViewModels.Auth
{
    class RegistrationViewModel:ViewModelBase
    {
        public string Name { get; set; } = string.Empty;

        private readonly INavigationService _navigationService;

        public RelayCommand NavigateToRegCommand { get; }

        public RegistrationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Name = string.Empty;

            NavigateToRegCommand = new RelayCommand(
                execute: () => _navigationService.NavigateTo<LoginView>(),
                canExecute: () => true
            );
        }

    }
}
