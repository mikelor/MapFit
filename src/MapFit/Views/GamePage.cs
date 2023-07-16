namespace MapFit.Views;

public partial class GamePage : ContentPage
{
	public GamePage(GameViewModel viewModel)
	{
		BindingContext = viewModel;

		Content = new ScrollView
		{
			Content = new VerticalStackLayout
			{
				Spacing = 25,

				Children =
				{
					new Image().Source("dotnet_bot.png")
								.Height(200)
								.CenterHorizontal()
								.SemanticDescription("Cute dot net bot waving hi to you!"),
					new Label().Text("Hello, World!")
								.FontSize(32)
								.CenterHorizontal()
								.SemanticHeadingLevel(SemanticHeadingLevel.Level1),
					new Label().Text("Welcome to .NET Multi-platform App UI")
								.FontSize(18)
								.CenterHorizontal()
								.SemanticHeadingLevel(SemanticHeadingLevel.Level2)
								.SemanticDescription("Welcome to dot net Multi platform App U I"),
					new Button().CenterHorizontal()
								.SemanticHint("Counts the number of times you click")
								.Bind(Button.TextProperty, nameof(GameViewModel.Message), BindingMode.OneWay)
								.BindCommand(nameof(GameViewModel.CounterClickedCommand))
				}
			}
			.Padding(30, 0)
			.CenterVertical()
		};
	}
}
