using MapFit.Resources.Styles;

namespace MapFit.Views;

public partial class ListDetailPage : ContentPage
{
	ListDetailViewModel ViewModel;

	public ListDetailPage(ListDetailViewModel viewModel)
	{
		BindingContext = ViewModel = viewModel;

		var itemTemplate = new DataTemplate(() => new Frame()
		{
			GestureRecognizers = {
			new TapGestureRecognizer().BindCommand(source: ViewModel, path: nameof(ListDetailViewModel.GoToDetailsCommand), parameterPath: "."),
			},
			Content = new Label().Bind(Label.TextProperty, nameof(SampleItem.Title))
							 .FontSize(18)
							 .AppThemeBinding(Label.TextColorProperty, AppStyles.Get("Primary"), AppStyles.Get("Black"))
		});

		Content = new RefreshView
		{
			Content = new CollectionView
			{
				RemainingItemsThreshold = 10,
			}.ItemTemplate(itemTemplate)
			 .Bind(CollectionView.ItemsSourceProperty, nameof(ListDetailViewModel.Items))
			 .Bind(CollectionView.RemainingItemsThresholdReachedCommandProperty, nameof(ListDetailViewModel.LoadMoreCommand))

		}.Bind(RefreshView.IsRefreshingProperty, nameof(ListDetailViewModel.IsRefreshing))
		 .BindCommand(nameof(ListDetailViewModel.RefreshingCommand));
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
