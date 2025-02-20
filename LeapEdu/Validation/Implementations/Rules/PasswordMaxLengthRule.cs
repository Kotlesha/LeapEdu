using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class PasswordMaxLengthRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } =
        $"Пароль не должен превышать {ValidationConstants.PasswordMaxLength} символов!";

    public bool Check(T value) =>
        value is string str && str.Length <= ValidationConstants.PasswordMaxLength;
}
