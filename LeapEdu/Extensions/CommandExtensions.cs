using System.Windows.Input;

namespace LeapEdu.Extensions;

internal static class CommandExtensions
{
    internal static void ExecuteIfCan(this ICommand command, object? parameter = null)
    {
        if (command.CanExecute(parameter)) command.Execute(parameter);
    }
}
