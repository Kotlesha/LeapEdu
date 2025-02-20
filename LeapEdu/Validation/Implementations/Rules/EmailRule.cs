using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class EmailRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = "Неверный адрес электронной почты!";

    public bool Check(T value) =>
        value is string str && ValidationConstants.EmailRegex.IsMatch(str);
}
