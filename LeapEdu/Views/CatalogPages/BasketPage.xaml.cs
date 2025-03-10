using System.Diagnostics;

namespace LeapEdu.Views.CatalogPages;

public partial class BasketPage : ContentPage
{
	public BasketPage()
	{
		InitializeComponent();

		var layout = this.FindByName<VerticalStackLayout>("Basket");

		for (int i = 0; i < 100; i++)
		{
			layout.Add(new Label { Text = $"{i}" });
			Debug.WriteLine(i);
        }
	}
}