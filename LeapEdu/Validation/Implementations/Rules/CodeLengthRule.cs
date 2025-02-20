using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class CodeLengthRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } 
        = $"Код подтверждения должен состоять из {ValidationConstants.CodeLength} символов.";

    public bool Check(T value) => value is string str && str.Length == ValidationConstants.CodeLength;
}
