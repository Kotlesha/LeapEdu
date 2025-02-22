using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Validation.Implementations;
using LeapEdu.Validation.Implementations.Rules;
using LeapEdu.Validation.Interfaces;

namespace LeapEdu.ViewModels;

public class RegisterViewModel : ObservableObject
{
    public ValidatableObject<string> Surname { get; private set; }
    public ValidatableObject<string> Name { get; private set; }
    public ValidatableObject<string> Email { get; private set; }
    public ValidatableObject<string> Password { get; private set; }
    public ValidatableObject<string> PasswordConfirmation { get; private set; }

    public RegisterViewModel()
    {
        Surname = new();
        Name = new();
        Email = new();
        Password = new();
        PasswordConfirmation = new();

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
    }

    public bool Validate()
    {
        Surname.ClearState();
        Name.ClearState();
        Email.ClearState();
        Password.ClearState();
        PasswordConfirmation.ClearState();

        var isValidSurname = Surname.Validate();
        var isValidName = Name.Validate();
        var isValidEmail = Email.Validate();
        var isValidPassword = Password.Validate();
        var isValidPasswordConfirmation = PasswordConfirmation.Validate();

        var result = isValidSurname 
            && isValidName 
            && isValidEmail 
            && isValidPassword 
            && isValidPasswordConfirmation;

        return result;
    }
}
