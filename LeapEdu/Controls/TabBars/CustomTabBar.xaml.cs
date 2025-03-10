using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LeapEdu.Controls.TabBars;

public partial class CustomTabBar : ContentView
{
    public ObservableCollection<CustomTabItem> TabItems { get; set; } = [];

    public static readonly BindableProperty CurrentTabProperty =
        BindableProperty.Create(
            nameof(CurrentTab),
            typeof(CustomTabItem),
            typeof(CustomTabBar),
            default(CustomTabItem),
            propertyChanged: OnCurrentTabChanged);

    public static readonly BindableProperty SelectionTabColorProperty =
        BindableProperty.Create(
            nameof(SelectionTabColor),
            typeof(Color),
            typeof(CustomTabBar),
            Colors.Grey);

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(int),
            typeof(CustomTabBar),
            default(int));

    public static readonly BindableProperty StrokeThicknessProperty =
        BindableProperty.Create(
            nameof(StrokeThickness),
            typeof(int),
            typeof(CustomTabBar),
            default(int));

    public static readonly BindableProperty SelectionTabHeightProperty =
        BindableProperty.Create(
            nameof(SelectionTabHeight),
            typeof(double),
            typeof(CustomTabBar),
            default(double));

    public static readonly BindableProperty SelectionTabWidthProperty =
        BindableProperty.Create(
            nameof(SelectionTabWidth),
            typeof(double),
            typeof(CustomTabBar),
            default(double));

    public static readonly BindableProperty SelectionTabCornerRadiusProperty =
        BindableProperty.Create(
            nameof(SelectionTabCornerRadius),
            typeof(double),
            typeof(CustomTabBar),
            default(double));

    public static readonly BindableProperty TabBarBackgroundColorProperty =
        BindableProperty.Create(
            nameof(TabBarBackgroundColor),
            typeof(Color),
            typeof(CustomTabBar),
            Colors.Grey);

    public CustomTabItem CurrentTab
    {
        get => (CustomTabItem)GetValue(CurrentTabProperty);
        set => SetValue(CurrentTabProperty, value);
    }

    public Color SelectionTabColor
    {
        get => (Color)GetValue(SelectionTabColorProperty);
        set => SetValue(SelectionTabColorProperty, value);
    }

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public int StrokeThickness
    {
        get => (int)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public double SelectionTabHeight
    {
        get => (double)GetValue(SelectionTabHeightProperty);
        set => SetValue(SelectionTabHeightProperty, value);
    }

    public double SelectionTabWidth
    {
        get => (double)GetValue(SelectionTabWidthProperty);
        set => SetValue(SelectionTabWidthProperty, value);
    }

    public double SelectionTabCornerRadius
    {
        get => (double)GetValue(SelectionTabCornerRadiusProperty);
        set => SetValue(SelectionTabCornerRadiusProperty, value);
    }

    public Color TabBarBackgroundColor
    {
        get => (Color)GetValue(TabBarBackgroundColorProperty);
        set => SetValue(TabBarBackgroundColorProperty, value);
    }

    public CustomTabBar()
	{
		InitializeComponent();

        Loaded += RoundedTabBar_Loaded;
        TabItems.CollectionChanged += TabItems_CollectionChanged;
	}

    private void TabItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
		if (e.Action != NotifyCollectionChangedAction.Add || e.NewItems is null) return;

        foreach (var newItem in e.NewItems)
        {
            var tab = (CustomTabItem)newItem;
            var index = TabItems.IndexOf(tab);

            TabGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            Grid.SetColumn(tab, index);
            TabGrid.Children.Add(tab);

            tab.TabTappedCommand = new Command(() => SetCurrentTab(tab));
        }
    }

    private void SetCurrentTab(CustomTabItem tab) => CurrentTab = tab;

    private async Task RefreshTabFocusColorAsync(CustomTabItem? oldTab, CustomTabItem? newTab)
    {
        oldTab?.SetFocusBorderBackgroundColor(Colors.Transparent);
        newTab?.SetFocusBorderBackgroundColor(SelectionTabColor);

        if (oldTab is not null && newTab is not null)
            await newTab.AnimateShowingFocusBorder();
    }

    private void RoundedTabBar_Loaded(object? sender, EventArgs e)
    {
        if (Parent is not null && TabItems.Count != 0 && CurrentTab is null)
            CurrentTab = TabItems[0];
    }

    private static async void OnCurrentTabChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var tabBar = bindable as CustomTabBar;
        var oldCurrentTab = oldValue as CustomTabItem;
        var newCurrentTab = newValue as CustomTabItem;

        await tabBar?.RefreshTabFocusColorAsync(oldCurrentTab, newCurrentTab);
    }

    protected override void OnParentSet()
    {
        if (Parent is null)
        {
            TabItems.CollectionChanged -= TabItems_CollectionChanged;
            Loaded -= RoundedTabBar_Loaded;
        }

        base.OnParentSet();
    }

    public void Update(CustomTabBar tabBar)
    {
        UpdateSizeProperties(tabBar);
        UpdateStyleProperties(tabBar);
        UpdateTabItems(tabBar);
    }

    private void UpdateSizeProperties(CustomTabBar tabBar)
    {
        HeightRequest = tabBar.HeightRequest;
        WidthRequest = tabBar.WidthRequest;
        MaximumHeightRequest = tabBar.MaximumHeightRequest;
        MaximumWidthRequest = tabBar.MaximumWidthRequest;
    }

    private void UpdateStyleProperties(CustomTabBar tabBar)
    {
        Margin = tabBar.Margin;
        Padding = tabBar.Padding;
        CornerRadius = tabBar.CornerRadius;
        StrokeThickness = tabBar.StrokeThickness;

        SelectionTabColor = tabBar.SelectionTabColor;
        SelectionTabHeight = tabBar.SelectionTabHeight;
        SelectionTabWidth = tabBar.SelectionTabWidth;
        SelectionTabCornerRadius = tabBar.SelectionTabCornerRadius;
        TabBarBackgroundColor = tabBar.TabBarBackgroundColor;
    }

    private void UpdateTabItems(CustomTabBar tabBar)
    {
        if (TabItems is null)
            return;

        TabItems.Clear();
        foreach (var item in tabBar.TabItems)
            TabItems.Add(item);
    }
}