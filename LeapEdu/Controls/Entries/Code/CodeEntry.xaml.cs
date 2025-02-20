using System.Windows.Input;

namespace LeapEdu.Controls.Entries.Code;

public partial class CodeEntry : ContentView
{
    public ICommand NextFocusCommand { get; }
    public ICommand PreviousFocusCommand { get; }

    public CodeEntry()
    {
        InitializeComponent();

        var grid = this.FindByName<Grid>("CodeGrid");

        NextFocusCommand = new Command<CodeEntryItem>(OnNextFocus);
        PreviousFocusCommand = new Command<CodeEntryItem>(OnPreviousFocus);

        foreach (var codeEntryItem in grid.Children.Cast<CodeEntryItem>()) 
        {
            codeEntryItem.NextFocusCommand = NextFocusCommand;
            codeEntryItem.PreviousFocusCommand = PreviousFocusCommand;
        }
    }

    private void OnNextFocus(CodeEntryItem currentItem)
    {
        var children = this.FindByName<Grid>("CodeGrid").Children;
        int index = children.IndexOf(currentItem);

        if (index < children.Count - 1 && children[index + 1] is CodeEntryItem nextItem)
        {
            nextItem.FocusCodeEntryItem();
        }
    }

    private void OnPreviousFocus(CodeEntryItem currentItem)
    {
        var children = this.FindByName<Grid>("CodeGrid").Children;
        int index = children.IndexOf(currentItem);

        if (index > 0 && children[index - 1] is CodeEntryItem previousItem)
        {
            previousItem.FocusCodeEntryItem();
        }
    }
}