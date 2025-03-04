using LeapEdu.Extensions;
using System.Windows.Input;

namespace LeapEdu.Controls.Entries.Code;

public partial class CodeEntryItem : ContentView
{
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

    public static readonly BindableProperty CodeChangedCommandProperty =
        BindableProperty.Create(
            nameof(CodeChangedCommand),
            typeof(ICommand),
            typeof(CodeEntryItem),
            default(ICommand));

    public string Text => Entry?.Text ?? string.Empty;

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

    public ICommand CodeChangedCommand
    {
        get => (ICommand)GetValue(CodeChangedCommandProperty);
        set => SetValue(CodeChangedCommandProperty, value);
    }

    public CodeEntryItem()
    {
        InitializeComponent();

        Entry.BackspacePressedOnEmpty += CodeEntryItem_BackspacePressedOnEmpty;
    }

    private void CodeEntryItem_Focused(object sender, FocusEventArgs e) 
        => EntryBorder.Stroke = Application.Current!.Resources.GetAppThemeColor("BorderColorFocused");

    private void CodeEntryItem_Unfocused(object sender, FocusEventArgs e) 
        => EntryBorder.Stroke = Application.Current!.Resources.GetAppThemeColor("BackgroundEntryColor");

    public void FocusCodeEntryItem() => Entry.Focus();

    private void CodeEntryItem_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!int.TryParse(e.NewTextValue, out _) && !string.IsNullOrEmpty(e.NewTextValue))
        {
            Entry.Text = string.Empty;
            return;
        }

        if (e.NewTextValue?.Length == 1) NextFocusCommand.ExecuteIfCan(this);

        CodeChangedCommand?.ExecuteIfCan(this);
    }

    private void CodeEntryItem_BackspacePressedOnEmpty(object? sender, EventArgs e)
    {
        PreviousFocusCommand.ExecuteIfCan(this);
        CodeChangedCommand?.ExecuteIfCan(this);
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is null)
            Entry.BackspacePressedOnEmpty -= CodeEntryItem_BackspacePressedOnEmpty;
    }
}