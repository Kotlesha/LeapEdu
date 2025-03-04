using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Extensions;

namespace LeapEdu.Controls.Entries;

public partial class RoundedEntry : ContentView
{
    private EventHandler<AppThemeChangedEventArgs>? _themeChangedHandler;

    public static readonly BindableProperty ValueProperty = 
        BindableProperty.Create(
            nameof(Value),
            typeof(string),
            typeof(RoundedEntry),
            default(string),
            BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderTextProperty =
        BindableProperty.Create(
            nameof(PlaceholderText), 
            typeof(string), 
            typeof(RoundedEntry), 
            default(string));

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(int),
            typeof(RoundedEntry),
            23);

    public static readonly BindableProperty MaxLengthProperty =
        BindableProperty.Create(
            nameof(MaxLength),
            typeof(int),
            typeof(RoundedEntry),
            int.MaxValue);

    public static readonly BindableProperty KeyboardTypeProperty =
        BindableProperty.Create(
            nameof(KeyboardType), 
            typeof(Keyboard), 
            typeof(RoundedEntry), 
            Keyboard.Default);

    public static readonly BindableProperty ErrorMessageProperty = 
        BindableProperty.Create(
            nameof(ErrorMessage), 
            typeof(string), 
            typeof(RoundedEntry), 
            string.Empty);

    public static readonly BindableProperty IsValidProperty = 
        BindableProperty.Create(
            nameof(IsValid), 
            typeof(bool), 
            typeof(RoundedEntry), 
            true,
            BindingMode.TwoWay,
            propertyChanged: OnIsValidPropertyChanged);

    public static readonly BindableProperty IsPasswordEntryProperty =
        BindableProperty.Create(
            nameof(IsPasswordEntry),
            typeof(bool),
            typeof(RoundedEntry),
            false,
            propertyChanged: OnIsPasswordEntryChanged);

    public static readonly BindableProperty ShowPasswordProperty =
        BindableProperty.Create(
            nameof(ShowPassword), 
            typeof(bool), 
            typeof(RoundedEntry), 
            false,
            propertyChanged: OnShowPasswordChanged);

    public static readonly BindableProperty EyeIconProperty =
        BindableProperty.Create(
            nameof(EyeIcon), 
            typeof(string), 
            typeof(RoundedEntry), 
            App.Current.Resources.GetAppThemeIcon("CloseEyeIcon"));


    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(
            nameof(BorderColor), 
            typeof(Color), 
            typeof(RoundedEntry), 
            Colors.Gray);

    public string Text => EntryField?.Text ?? string.Empty;

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }

    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public bool IsPasswordEntry
    {
        get => (bool)GetValue(IsPasswordEntryProperty);
        set => SetValue(IsPasswordEntryProperty, value);
    }

    public bool ShowPassword
    {
        get => (bool)GetValue(ShowPasswordProperty);
        private set => SetValue(ShowPasswordProperty, value);
    }

    public string EyeIcon
    {
        get => (string)GetValue(EyeIconProperty);
        private set => SetValue(EyeIconProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public RoundedEntry()
    {
        InitializeComponent();

        _themeChangedHandler = (o, e) =>
        {
            UpdateBorderColor();
            UpdateEyeIcon();
        };

        App.Current!.RequestedThemeChanged += _themeChangedHandler;
    }

    private void EntryField_Focused(object sender, FocusEventArgs e) => UpdateBorderColor();

    private void EntryField_Unfocused(object sender, FocusEventArgs e) => UpdateBorderColor();

    private void ChangePasswordVisibility(object sender, EventArgs e)
    {
        ShowPassword = !ShowPassword;
        UpdateEyeIcon();
    }

    private static void OnIsValidPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoundedEntry entry) entry.UpdateBorderColor();
    }

    private static void OnIsPasswordEntryChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoundedEntry entry && newValue is bool showPassword) 
            entry.ShowPassword = showPassword;
    }

    private static void OnShowPasswordChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoundedEntry entry)
            entry.UpdateEyeIcon();
    }

    private void UpdateBorderColor()
    {
        var resources = Application.Current!.Resources;

        var validColor = resources.GetAppThemeColor("BackgroundEntryColor");
        var focusedColor = resources.GetAppThemeColor("BorderColorFocused");
        var invalidColor = resources.GetAppThemeColor("InvalidDataColor");

        if (EntryField.IsFocused)
        {
            EntryBorder.Stroke = focusedColor;
            return;
        }

        EntryBorder.Stroke = IsValid ? validColor : invalidColor;
    }

    private void UpdateEyeIcon()
    {
        var iconKey = ShowPassword ? "OpenEyeIcon" : "CloseEyeIcon";
        EyeIcon = (string)App.Current.Resources.GetAppThemeIcon(iconKey);
    }

    public async Task RemoveFocusAsync(CancellationToken cancellationToken = default)
    {
        if (EntryField.IsSoftInputShowing())
            await EntryField.HideKeyboardAsync(cancellationToken);
    }

    protected override void OnParentSet()
    {
        if (Parent is null && _themeChangedHandler is not null)
        {
            App.Current!.RequestedThemeChanged -= _themeChangedHandler;
            _themeChangedHandler = null;
        }

        base.OnParentSet();
    }
}