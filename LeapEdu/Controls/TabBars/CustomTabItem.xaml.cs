using System.Windows.Input;

namespace LeapEdu.Controls.TabBars;

public partial class CustomTabItem : ContentView
{
    public static readonly BindableProperty TargetPageTypeProperty =
        BindableProperty.Create(
            nameof(TargetPageType),
            typeof(Type),
            typeof(CustomTabItem),
            default(Type));

    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(
            nameof(ImageSource), 
            typeof(string), 
            typeof(CustomTabItem), 
            default(string));

    public static readonly BindableProperty TabTappedCommandProperty =
        BindableProperty.Create(
            nameof(TabTappedCommand),
            typeof(ICommand),
            typeof(CustomTabItem),
            default(ICommand));

    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public ICommand TabTappedCommand
    {
        get => (ICommand)GetValue(TabTappedCommandProperty);
        set => SetValue(TabTappedCommandProperty, value);
    }

    public Type TargetPageType
    {
        get => (Type)GetValue(TargetPageTypeProperty);
        set => SetValue(TargetPageTypeProperty, value);
    }

    public CustomTabItem() => InitializeComponent();

    public void SetFocusBorderBackgroundColor(Color color) => FocusBorder.BackgroundColor = color;

    public async Task AnimateShowingFocusBorder()
    {
        FocusBorder.Opacity = 0;
        await FocusBorder.FadeTo(1, 250, Easing.CubicInOut);
    }
}