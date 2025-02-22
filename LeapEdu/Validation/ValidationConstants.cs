using System.Text.RegularExpressions;

namespace LeapEdu.Validation;

public static class ValidationConstants
{
    public const int PasswordMinLength = 8;
    public const int PasswordMaxLength = 15;
    public const string SpecialCharacters = "!@#$%^&*()_+-=[]{}|;:'\",.<>?/";
    public const int CodeLength = 6;

    public static readonly Regex EmailRegex
        = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    public static readonly Regex LowercaseLetterRegex = new(@"[a-z]");
    public static readonly Regex UppercaseLetterRegex = new(@"[A-Z]");
}
