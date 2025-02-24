using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class IsCheckedRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }
        = "Вы должны отметить этот пункт!";

    public bool Check(T value) => value is bool accepted && accepted;
}
