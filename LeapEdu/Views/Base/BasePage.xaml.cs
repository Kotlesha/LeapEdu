using LeapEdu.Services.Interfaces;
using System.Windows.Input;

namespace LeapEdu.Views.Base;

public partial class BasePage : ContentPage
{
    public static readonly BindableProperty ShowBackButtonProperty =
        BindableProperty.Create(
            nameof(ShowBackButton), 
            typeof(bool), 
            typeof(BasePage), 
            false);

    public static readonly BindableProperty BackCommandProperty =
        BindableProperty.Create(
            nameof(BackCommand),
            typeof(ICommand),
            typeof(BasePage),
            default(ICommand));

    public static readonly BindableProperty RemoveFocusCommandProperty =
        BindableProperty.Create(
            nameof(RemoveFocusCommand),
            typeof(ICommand),
            typeof(BasePage),
            default(ICommand));

    public bool ShowBackButton
    {
        get => (bool)GetValue(ShowBackButtonProperty);
        set => SetValue(ShowBackButtonProperty, value);
    }

    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    public ICommand RemoveFocusCommand
    {
        get => (ICommand)GetValue(RemoveFocusCommandProperty);
        set => SetValue(RemoveFocusCommandProperty, value);
    }

    public BasePage()
	{
        InitializeComponent();

        var navigationService = Application
            .Current?
            .Handler?
            .MauiContext?
            .Services
            .GetService<INavigationService>();

        BackCommand = new Command(async () =>
        {
            await navigationService?.GoBackAsync()!;
        });
	}
}