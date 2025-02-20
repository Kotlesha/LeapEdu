using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = "Поле не может быть пустым!";

    public bool Check(T value) =>
        value is string str && !string.IsNullOrWhiteSpace(str);
}