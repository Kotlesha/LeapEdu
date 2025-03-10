using LeapEdu.Services.Interfaces;
using LeapEdu.Validation.Implementations;
using LeapEdu.Validation.Implementations.Rules;
using LeapEdu.ViewModels.Base;

namespace LeapEdu.ViewModels.Auth;

public partial class LoginViewModel : BaseNavigationModel
{
    public ValidatableObject<string> Email { get; private set; }
    public ValidatableObject<string> Password { get; private set; }

    public LoginViewModel(INavigationService navigationService)
        : base(navigationService)
    {
        Email = new();
        Password = new();

        AddValidations();
    }

    private void AddValidations()
    {
        Email.Validations.AddRange([
            new IsNotNullOrEmptyRule<string>(), 
            new EmailRule<string>()]);

        Password.Validations.Add(new IsNotNullOrEmptyRule<string>());
    }

    public bool Validate()
    {
        var isValidEmail = Email.Validate();
        var isValidPassword = Password.Validate();
        return isValidEmail && isValidPassword;
    }
}
