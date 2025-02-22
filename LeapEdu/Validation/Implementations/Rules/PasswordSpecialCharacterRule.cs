using LeapEdu.Validation.Interfaces;

namespace LeapEdu.Validation.Implementations.Rules;

public class PasswordSpecialCharacterRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } =
        $"Пароль должен содержать хотя бы один специальный символ из {ValidationConstants.SpecialCharacters}!";

    public bool Check(T value) =>
        value is string str && str.Any(ValidationConstants.SpecialCharacters.Contains);
}
