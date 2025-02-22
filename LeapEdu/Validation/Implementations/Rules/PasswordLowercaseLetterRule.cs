using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class PasswordLowercaseLetterRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } =
        "Пароль должен содержать хотя бы одну строчную латинскую букву!";

    public bool Check(T value) =>
        value is string str && ValidationConstants.LowercaseLetterRegex.IsMatch(str);
}
