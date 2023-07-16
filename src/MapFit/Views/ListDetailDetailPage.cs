namespace MapFit.Views;

public partial class ListDetailDetailPage : ContentPage
{
	public ListDetailDetailPage(ListDetailDetailViewModel viewModel)
	{
		BindingContext = viewModel;

		Content = new ScrollView
		{
			Content = new VerticalStackLayout
			{
				Children = {
					new Label().FontSize(20).Bind(Label.TextProperty, "Item.Title"),
					new Label().Bind(Label.TextProperty, "Item.Description"),
					}
			}.Margin(12),
		};

	}
}
