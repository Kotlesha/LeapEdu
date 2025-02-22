using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class MatchFieldRule<T>(ValidatableObject<T> otherField) : IValidationRule<T>
{
    private readonly ValidatableObject<T> _otherField = otherField;

    public string ValidationMessage { get; set; } = "Пароли не совпадают!";

    public bool Check(T value)
    {
        return EqualityComparer<T>.Default.Equals(_otherField.Value, value);
    }
}

