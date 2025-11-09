using HabbitFlow.Utilities;
using HabbitFlow.Views;
using HabbitFlow.Views.Auth;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using INavigationService = HabbitFlow.Utilities.INavigationService;
// Добавьте это в самый верх файла, перед всеми using
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace HabbitFlow.ViewModels.Auth
{
    class RegistrationViewModel:ViewModelBase
    {



        public string Name { get; set; } = string.Empty;

        private readonly INavigationService _navigationService;

        public RelayCommand NavigateToLoginCommand { get; }

        public RegistrationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Name = string.Empty;

            NavigateToLoginCommand  = new RelayCommand(
                execute: () => _navigationService.NavigateTo<LoginView>(),
                canExecute: () => true
            );
        }



        
    }
}
