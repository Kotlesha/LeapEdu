using LeapEdu.Controls.Popups;
using LeapEdu.Services.Interfaces;
using LeapEdu.Validation.Implementations;
using LeapEdu.Validation.Implementations.Rules;
using LeapEdu.Validation.Interfaces;
using LeapEdu.ViewModels.Base;
using Mopups.Interfaces;
using System.Windows.Input;

namespace LeapEdu.ViewModels;

public partial class RegisterViewModel : BaseNavigationModel
{
    public ValidatableObject<string> Surname { get; private set; }
    public ValidatableObject<string> Name { get; private set; }
    public ValidatableObject<string> Email { get; private set; }
    public ValidatableObject<string> Password { get; private set; }
    public ValidatableObject<string> PasswordConfirmation { get; private set; }
    public ValidatableObject<bool> TermsAccepted { get; private set; }

    public ICommand OpenPrivacyPolicyCommand { get; }
    public ICommand OpenTermsOfUseCommand { get; }

    private readonly IPopupNavigation _popupNavigation;

    public RegisterViewModel(INavigationService navigationService, IPopupNavigation popupNavigation)
        : base(navigationService)
    {
        _popupNavigation = popupNavigation;

        OpenPrivacyPolicyCommand = new Command(async () => await OpenLegalNoticesPopup("privacy_policy.md"));
        OpenTermsOfUseCommand = new Command(async () => await OpenLegalNoticesPopup("terms_of_use.md"));

        Surname = new();
        Name = new();
        Email = new();
        Password = new();
        PasswordConfirmation = new();
        TermsAccepted = new();

        AddValidations();
    }

    private void AddValidations()
    {
        Surname.Validations.Add(new IsNotNullOrEmptyRule<string>());
        Name.Validations.Add(new IsNotNullOrEmptyRule<string>());

        Email.Validations.AddRange([
            new IsNotNullOrEmptyRule<string>(),
            new EmailRule<string>()]);


        var passwordRules = new List<IValidationRule<string>>()
        {
            new IsNotNullOrEmptyRule<string>(),
            new PasswordMinLengthRule<string>(),
            new PasswordMaxLengthRule<string>(),
            new PasswordLowercaseLetterRule<string>(),
            new PasswordUppercaseLetterRule<string>(),
            new PasswordDigitRule<string>(),
            new PasswordSpecialCharacterRule<string>()
        };

        Password.Validations.AddRange(passwordRules);

        PasswordConfirmation.Validations.AddRange([
            new IsNotNullOrEmptyRule<string>(),
            new MatchFieldRule<string>(Password)
        ]);

        TermsAccepted.Validations.Add(new IsCheckedRule<bool>());
    }

    public bool Validate()
    {
        bool isValid = true;

        var fields = new IValidity[]
        {
            Surname,
            Name,
            Email,
            Password,
            PasswordConfirmation,
            TermsAccepted
        };

        foreach (var field in fields)
            if (!field.Validate()) isValid = false;

        return isValid;
    }

    private async Task OpenLegalNoticesPopup(string path)
    {
        var viewModel = new LegalNoticiesViewModel(path);

        await _popupNavigation.PushAsync(new LegalNoticesPopup(viewModel), true);
        await viewModel.LoadDataAsync();
    }
}
