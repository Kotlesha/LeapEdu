using LeapEdu.Controls.TabBars;

namespace LeapEdu.Views.Base;

public partial class CustomTabbedPage : ContentPage
{
    private double _lastScrollY = 0;
    private double _targetTranslation = 0;

    public CustomTabbedPage()
    {
        InitializeComponent();

        TabBarControl.PropertyChanged += CurrentTab_PropertyChanged;
        PageContainer.Scrolled += PageContainer_Scrolled;
    }

    public static readonly BindableProperty TabBarProperty =
        BindableProperty.Create(
            nameof(TabBar),
            typeof(CustomTabBar),
            typeof(CustomTabbedPage),
            default(CustomTabBar),
            propertyChanged: OnTabBarChanged);

    public CustomTabBar TabBar
    {
        get => (CustomTabBar)GetValue(TabBarProperty);
        set => SetValue(TabBarProperty, value);
    }

    private static void OnTabBarChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var page = (CustomTabbedPage)bindable;

        if (newValue is CustomTabBar newTabBar)
            page.TabBarControl.Update(newTabBar);
    }

    private void CurrentTab_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(TabBarControl.CurrentTab))
            return;

        var selectedTab = TabBarControl.CurrentTab;
        if (selectedTab is null)
            return;

        if (selectedTab.TargetPageType is not Type pageType) return;

        var services = Application
            .Current?
            .Handler?
            .MauiContext?
            .Services;

        if (services?.GetService(pageType) is ContentPage pageInstance)
        {
            PageContainer.Content = pageInstance.Content;
            PageContainer.BindingContext = pageInstance.BindingContext;
        }
    }

    private void PageContainer_Scrolled(object? sender, ScrolledEventArgs e)
    {
        double delta = e.ScrollY - _lastScrollY;
        _lastScrollY = e.ScrollY;

        _targetTranslation += delta;

        double maxTranslationY = TabBarControl.Height + TabBarControl.Margin.Bottom;
        _targetTranslation = Math.Max(0, Math.Min(maxTranslationY, _targetTranslation));

        TabBarControl.TranslationY = _targetTranslation;
    }

    protected override void OnParentSet()
    {
        if (Parent is null)
            TabBarControl.CurrentTab.PropertyChanged -= CurrentTab_PropertyChanged;

        base.OnParentSet();
    }
}