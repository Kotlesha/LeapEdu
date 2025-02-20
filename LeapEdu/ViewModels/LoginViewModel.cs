using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Validation.Implementations;
using LeapEdu.Validation.Implementations.Rules;

namespace LeapEdu.ViewModels;

public class LoginViewModel : ObservableObject
{
    public ValidatableObject<string> Email { get; private set; }
    public ValidatableObject<string> Password { get; private set; }

    public LoginViewModel()
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
        Email.ClearState();
        Password.ClearState();

        var isValidEmail = Email.Validate();
        var isValidPassword = Password.Validate();
        return isValidEmail && isValidPassword;
    }
}
