namespace LeapEdu.Controls.Entries;

public partial class RoundedEntry : ContentView
{
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
            27);

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
            false);

    public static readonly BindableProperty EyeIconProperty =
        BindableProperty.Create(
            nameof(EyeIcon), 
            typeof(string), 
            typeof(RoundedEntry), 
            "close_eye_icon.svg");

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
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
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

    public RoundedEntry() => InitializeComponent();

    private void EntryField_Focused(object sender, FocusEventArgs e) 
        => EntryBorder.Stroke = Application.Current!.Resources["BorderColorFocused"] as Color;

    private void EntryField_Unfocused(object sender, FocusEventArgs e) => UpdateBorderColor();

    private void ChangePasswordVisibility(object sender, EventArgs e) => ShowPassword = !ShowPassword;

    private static void OnIsValidPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoundedEntry entry) entry.UpdateBorderColor();
    }

    private static void OnIsPasswordEntryChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RoundedEntry entry && newValue is bool showPassword) 
            entry.ShowPassword = showPassword;
    }

    private void UpdateBorderColor()
    {
        var resources = Application.Current!.Resources;

        var validColor = (Color)resources["BackgroundEntryColor"];
        var focusedColor = (Color)resources["BorderColorFocused"];
        var invalidColor = (Color)resources["InvalidDataColor"];

        if (EntryField.IsFocused)
        {
            EntryBorder.Stroke = focusedColor;
            return;
        }

        EntryBorder.Stroke = IsValid ? validColor : invalidColor;
    }
}