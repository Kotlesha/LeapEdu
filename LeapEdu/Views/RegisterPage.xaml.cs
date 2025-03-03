using LeapEdu.Controls.Popups;
using LeapEdu.Validation;
using LeapEdu.ViewModels;
using LeapEdu.Views.Base;
using Mopups.Interfaces;
using Mopups.Services;

namespace LeapEdu.Views;

public partial class RegisterPage : BasePage
{
    private readonly RegisterViewModel _registerViewModel;
    private readonly IPopupNavigation _popupNavigation;

    public RegisterPage(RegisterViewModel registerViewModel, IPopupNavigation popupNavigation)
    {
        InitializeComponent();

        _registerViewModel = registerViewModel;
        BindingContext = registerViewModel;
        _popupNavigation = popupNavigation;

        RemoveFocusCommand = new Command(async () 
            => await NameRoundedEntry.RemoveFocusAsync(CancellationToken.None));
    }

    private void RegisterButton_Pressed(object sender, EventArgs e) => _registerViewModel.Validate();

    private async void TermsOfUse_Tapped(object sender, TappedEventArgs e)
    {
        var viewModel = new LegalNoticiesViewModel("terms_of_use.md");

        await _popupNavigation.PushAsync(new LegalNoticesPopup(viewModel), true);
        await viewModel.LoadDataAsync();
    }

    private async void PrivacyPolicy_Tapped(object sender, TappedEventArgs e)
    {
        var viewModel = new LegalNoticiesViewModel("privacy_policy.md");

        await _popupNavigation.PushAsync(new LegalNoticesPopup(viewModel), true);
        await viewModel.LoadDataAsync();
    }

    private async void PasswordQuestionButton_Pressed(object sender, EventArgs e)
    {
        var passwordRequirementsText = string.Join("\n", [
            $"1.От {ValidationConstants.PasswordMinLength} до {ValidationConstants.PasswordMaxLength} символов.",
            "2.Хотя бы одна прописная латинская буква.",
            "3.Хотя бы одна строчная латинская буква.",
            "4.Хотя бы одна цифра.",
            $"5.Хотя бы один специальный символ из перечисленных {ValidationConstants.SpecialCharacters}" ]);

        var alertPopupViewModel = new AlertPopupViewModel(
            title: "Требования к паролю",
            message: passwordRequirementsText);

        await _popupNavigation.PushAsync(new AlertPopup(alertPopupViewModel));
    }

    private async void RepeatImageButton_Pressed(object sender, EventArgs e)
    {
        var alertPopupViewModel = new AlertPopupViewModel(
            title: "Требования к паролю",
            message: """Поля "Повторите пароль" и "Пароль" должны содержать одинаковые данные""");

        await _popupNavigation.PushAsync(new AlertPopup(alertPopupViewModel));
    }
}