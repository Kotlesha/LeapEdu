using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations;

public partial class ValidatableObject<T> : ObservableObject, IValidity<T>
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FirstError))]
    private IEnumerable<string> errors = [];

    [ObservableProperty]
    private bool isValid = true;

    [ObservableProperty]
    private T value;

    partial void OnValueChanged(T value) => ClearState();

    public List<IValidationRule<T>> Validations { get; } = [];

    public string? FirstError => Errors?.FirstOrDefault();

    public void ClearState()
    {
        IsValid = true;
        Errors = [];
    }

    public bool Validate()
    {
        Errors = Validations
            ?.Where(v => !v.Check(Value))
            ?.Select(v => v.ValidationMessage)
            ?.ToArray()
            ?? Enumerable.Empty<string>();

        IsValid = !Errors.Any();
        return IsValid;
    }
}
