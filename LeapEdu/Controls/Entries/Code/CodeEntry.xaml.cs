using CommunityToolkit.Maui.Core.Platform;
using System.Windows.Input;

namespace LeapEdu.Controls.Entries.Code;

public partial class CodeEntry : ContentView
{
    public static readonly BindableProperty CodeProperty =
        BindableProperty.Create(
            nameof(Code),
            typeof(string),
            typeof(CodeEntry),
            default(string),
            BindingMode.TwoWay);

    public string Code
    {
        get => (string)GetValue(CodeProperty);
        set => SetValue(CodeProperty, value);
    }

    public ICommand NextFocusCommand { get; }
    public ICommand PreviousFocusCommand { get; }
    public ICommand CodeChangedCommand { get; }

    public CodeEntry()
    {
        InitializeComponent();

        NextFocusCommand = new Command<CodeEntryItem>(OnNextFocus);
        PreviousFocusCommand = new Command<CodeEntryItem>(OnPreviousFocus);
        CodeChangedCommand = new Command(UpdateCode);

        foreach (var codeEntryItem in CodeGrid.Children.Cast<CodeEntryItem>()) 
        {
            codeEntryItem.NextFocusCommand = NextFocusCommand;
            codeEntryItem.PreviousFocusCommand = PreviousFocusCommand;
            codeEntryItem.CodeChangedCommand = CodeChangedCommand;
        }
    }

    private void OnNextFocus(CodeEntryItem currentItem)
    {
        var children = CodeGrid.Children;
        int index = children.IndexOf(currentItem);

        if (index < children.Count - 1 && children[index + 1] is CodeEntryItem nextItem)
            nextItem.FocusCodeEntryItem();
    }

    private void OnPreviousFocus(CodeEntryItem currentItem)
    {
        var children = CodeGrid.Children;
        int index = children.IndexOf(currentItem);

        if (index > 0 && children[index - 1] is CodeEntryItem previousItem)
            previousItem.FocusCodeEntryItem();
    }

    public void UpdateCode()
    {
        Code = string.Concat(CodeGrid.Children
            .OfType<CodeEntryItem>()
            .Select(item => item.Text));
    }

    public async Task RemoveFocusAsync(CancellationToken cancellationToken = default)
    {
        var codeEntryItem = CodeGrid.Children.FirstOrDefault() as CodeEntryItem;
        var enrty = codeEntryItem.FindByName<Entry>("Entry");

        if (enrty.IsSoftInputShowing())
            await enrty.HideKeyboardAsync(cancellationToken);
    }
}