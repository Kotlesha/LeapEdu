using LeapEdu.Services.Interfaces;
using LeapEdu.Validation.Implementations;
using LeapEdu.Validation.Implementations.Rules;
using LeapEdu.ViewModels.Base;

namespace LeapEdu.ViewModels;

public partial class RepairPasswordViewModel : BaseNavigationModel
{
    public ValidatableObject<string> Email { get; private set; }

    public RepairPasswordViewModel(INavigationService navigationService)
        : base(navigationService)
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

    public bool Validate() => Email.Validate();
}
