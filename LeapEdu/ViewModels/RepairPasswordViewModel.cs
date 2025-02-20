using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Validation.Implementations;
using LeapEdu.Validation.Implementations.Rules;

namespace LeapEdu.ViewModels;

public class RepairPasswordViewModel : ObservableObject
{
    public ValidatableObject<string> Email { get; private set; }

    public RepairPasswordViewModel()
    {
        Email = new();

        AddValidations();
    }

    private void AddValidations()
    {
        Email.Validations.AddRange([
            new IsNotNullOrEmptyRule<string>(),
            new EmailRule<string>()]);
    }

    public bool Validate()
    {
        Email.ClearState();

        return Email.Validate();
    }
}
