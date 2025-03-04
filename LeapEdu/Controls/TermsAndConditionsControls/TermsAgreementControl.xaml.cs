using System.Windows.Input;

namespace LeapEdu.Controls.TermsAndConditionsControls;

public partial class TermsAgreementControl : ContentView
{
    public static readonly BindableProperty IsCheckedProperty =
        BindableProperty.Create(
            nameof(IsChecked),
            typeof(bool),
            typeof(TermsAgreementControl),
            false,
            BindingMode.TwoWay);

    public static readonly BindableProperty IsValidProperty =
        BindableProperty.Create(
            nameof(IsValid),
            typeof(bool),
            typeof(TermsAgreementControl),
            true);

    public static readonly BindableProperty PrivacyPolicyCommandProperty =
        BindableProperty.Create(
            nameof(PrivacyPolicyCommand),
            typeof(ICommand),
            typeof(TermsAgreementControl));

    public static readonly BindableProperty TermsOfUseCommandProperty =
        BindableProperty.Create(
            nameof(TermsOfUseCommand),
            typeof(ICommand),
            typeof(TermsAgreementControl));

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public ICommand PrivacyPolicyCommand
    {
        get => (ICommand)GetValue(PrivacyPolicyCommandProperty);
        set => SetValue(PrivacyPolicyCommandProperty, value);
    }

    public ICommand TermsOfUseCommand
    {
        get => (ICommand)GetValue(TermsOfUseCommandProperty);
        set => SetValue(TermsOfUseCommandProperty, value);
    }

    public TermsAgreementControl()
	{
		InitializeComponent();

        App.Current!.RequestedThemeChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(IsValid));
            OnPropertyChanged(nameof(IsChecked));
        };
    }
}