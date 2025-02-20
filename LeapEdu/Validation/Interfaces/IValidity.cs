namespace LeapEdu.Validation.Interfaces;

public interface IValidity<T>
{
    IEnumerable<string> Errors { get; }
    string? FirstError { get; }
    bool IsValid { get; }
    List<IValidationRule<T>> Validations { get; }
    bool Validate();
    void ClearState();
}
