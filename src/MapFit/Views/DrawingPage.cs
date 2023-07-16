using CommunityToolkit.Maui.Views;

using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MapFit.Views;

public partial class DrawingPage : ContentPage
{
	readonly Image generatedImage;

	public DrawingPage(DrawingViewModel viewModel)
	{
		BindingContext = viewModel;

		var saveButton = new Button().Text("Save").Row(1).Column(1);
		saveButton.Clicked += SaveClicked;

		Content = new Grid
		{
			ColumnDefinitions = Columns.Define(Star, Star),
			RowDefinitions = Rows.Define(Star, Auto, Star),
			Children =
			{
				new DrawingView { IsMultiLineModeEnabled = true }
						.ColumnSpan(2).Bind(DrawingView.LinesProperty, nameof(DrawingViewModel.Lines)),
				new Button().Text("Clear").Row(1).Column(0).BindCommand(nameof(DrawingViewModel.ClearCommand)),
				saveButton,
				new Image().Assign(out generatedImage).Row(2).ColumnSpan(2),
			}
		};
	}

	private async void SaveClicked(object sender, EventArgs e)
	{
		var drawingLines = (BindingContext as DrawingViewModel).Lines.ToList();
		var points = drawingLines.SelectMany(x => x.Points).ToList();

		var stream = await DrawingView.GetImageStream(
			drawingLines,
			new Size(points.Max(x => x.X) - points.Min(x => x.X), points.Max(x => x.Y) - points.Min(x => x.Y)),
			Colors.Gray);

		generatedImage.Source = ImageSource.FromStream(() => stream);
	}
}
