using LeapEdu.Extensions;
using System.Windows.Input;

namespace LeapEdu.Controls.Entries.Code;

public partial class CodeEntryItem : ContentView
{
    private BackspaceEntry? _codeEntryItem;

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(int),
            typeof(CodeEntryItem),
            27);

    public static readonly BindableProperty PreviousFocusCommandProperty =
        BindableProperty.Create(
            nameof(PreviousFocusCommand),
            typeof(ICommand),
            typeof(CodeEntryItem),
            default(ICommand));

    public static readonly BindableProperty NextFocusCommandProperty =
        BindableProperty.Create(
            nameof(NextFocusCommand),
            typeof(ICommand),
            typeof(CodeEntryItem),
            default(ICommand));

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public ICommand PreviousFocusCommand
    {
        get => (ICommand)GetValue(PreviousFocusCommandProperty);
        set => SetValue(PreviousFocusCommandProperty, value);
    }

    public ICommand NextFocusCommand
    {
        get => (ICommand)GetValue(NextFocusCommandProperty);
        set => SetValue(NextFocusCommandProperty, value);
    }

    public CodeEntryItem()
    {
        InitializeComponent();

        _codeEntryItem = this.FindByName<BackspaceEntry>("CodeEntry");
        _codeEntryItem.BackspacePressedOnEmpty += CodeEntryItem_BackspacePressedOnEmpty;
    }

    private void CodeEntryItem_Focused(object sender, FocusEventArgs e)
    {
        var border = this.FindByName<Border>("EntryBorder");
        border.Stroke = Colors.Black;
    }

    private void CodeEntryItem_Unfocused(object sender, FocusEventArgs e)
    {
        var border = this.FindByName<Border>("EntryBorder");
        border.Stroke = Application.Current!.Resources["BackgroundEntryColor"] as Color;
    }

    public void FocusCodeEntryItem()
    {
        var entry = this.FindByName<BackspaceEntry>("CodeEntry");
        entry.Focus();
    }

    private void CodeEntryItem_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!int.TryParse(e.NewTextValue, out _))
        {
            var entry = this.FindByName<Entry>("CodeEntry");
            entry.Text = string.Empty;
            return;
        }

        if (e.NewTextValue?.Length == 1) NextFocusCommand.ExecuteIfCan(this);
    }

    private void CodeEntryItem_BackspacePressedOnEmpty(object? sender, EventArgs e)
    {
        PreviousFocusCommand.ExecuteIfCan(this);
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is null && _codeEntryItem is not null)
        {
            _codeEntryItem.BackspacePressedOnEmpty -= CodeEntryItem_BackspacePressedOnEmpty;
            _codeEntryItem = null;
        }
    }
}