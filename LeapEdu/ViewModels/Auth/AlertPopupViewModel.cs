﻿using CommunityToolkit.Mvvm.ComponentModel;
using Mopups.Services;
using System.Windows.Input;

namespace LeapEdu.ViewModels.Auth;

public partial class AlertPopupViewModel : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string message;

    [ObservableProperty]
    private string buttonText;

    //public string Title
    //{
    //    get => _title;
    //    set => SetProperty(ref _title, value);
    //}

    //public string Message
    //{
    //    get => _message;
    //    set => SetProperty(ref _message, value);
    //}

    //public string ButtonText
    //{
    //    get => _buttonText;
    //    set => SetProperty(ref _buttonText, value);
    //}

    public ICommand CloseCommand { get; }

    public AlertPopupViewModel(
        string title = "Уведомление", 
        string message = "Важная информация!", 
        string buttonText = "Понятно", 
        ICommand? closeCommand = null)
    {
        Title = title;
        Message = message;
        ButtonText = buttonText;
        CloseCommand = closeCommand ?? new Command(
            async () => await MopupService.Instance.PopAsync());
    }
}
