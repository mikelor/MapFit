namespace MapFit;

public class AppShell : Shell
{
	public AppShell(MainPage Main, GamePage Game, DrawingPage Drawing, ListDetailPage ListDetail, MapPage Map)
	{
		Routing.RegisterRoute(nameof(ListDetailDetailPage), typeof(ListDetailDetailPage));
		Items.Add(new ShellContent { Title = "Main", Icon = ImageSource.FromFile("iconblank.png"), Content = Main });
		Items.Add(new ShellContent { Title = "Game", Icon = ImageSource.FromFile("iconsample.png"), Content = Game });
		Items.Add(new ShellContent { Title = "Drawing", Icon = ImageSource.FromFile("icondrawing.png"), Content = Drawing });
		Items.Add(new ShellContent { Title = "ListDetail", Icon = ImageSource.FromFile("iconlistdetail.png"), Content = ListDetail });
		Items.Add(new ShellContent { Title = "Map", Icon = ImageSource.FromFile("iconmap.png"), Content = Map });
	}
}
