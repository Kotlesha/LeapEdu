using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class PasswordMinLengthRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } =
        $"Пароль должен содержать минимум {ValidationConstants.PasswordMinLength} символов!";

    public bool Check(T value) =>
        value is string str && str.Length >= ValidationConstants.PasswordMinLength;
}
