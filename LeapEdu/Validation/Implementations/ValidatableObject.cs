using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations;

public class ValidatableObject<T> : ObservableObject, IValidity<T>
{
    private IEnumerable<string> _errors = [];
    private bool _isValid = true;
    private T _value;

    public List<IValidationRule<T>> Validations { get; } = [];

    public IEnumerable<string> Errors
    {
        get => _errors;
        private set
        {
            if (SetProperty(ref _errors, value))
                OnPropertyChanged(nameof(FirstError));
        }
    }

    public string? FirstError => Errors?.FirstOrDefault();

    public bool IsValid
    {
        get => _isValid;
        private set => SetProperty(ref _isValid, value);
    }

    public T Value
    {
        get => _value;
        set {
            
            if (SetProperty(ref _value, value))
            {
                ClearState();
                OnPropertyChanged(nameof(IsValid));
            }
        }
    }

    public void ClearState()
    {
        _isValid = true;
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
