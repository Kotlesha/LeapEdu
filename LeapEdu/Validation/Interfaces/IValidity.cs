namespace LeapEdu.Validation.Interfaces;

public interface IValidity
{
    IEnumerable<string> Errors { get; }
    string? FirstError { get; }
    bool IsValid { get; }
    bool Validate();
    void ClearState();
}

public interface IValidity<T> : IValidity
{
    T Value { get; set; }
    List<IValidationRule<T>> Validations { get; }
}
