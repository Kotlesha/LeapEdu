using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class PasswordUppercaseLetterRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } =
        "Пароль должен содержать хотя бы одну заглавную латинскую букву!";

    public bool Check(T value) =>
        value is string str && ValidationConstants.UppercaseLetterRegex.IsMatch(str);
}