using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class PasswordDigitRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } =
        "Пароль должен содержать хотя бы одну цифру!";

    public bool Check(T value) =>
        value is string str && str.Any(char.IsDigit);
}
