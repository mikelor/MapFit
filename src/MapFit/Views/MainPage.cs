﻿namespace MapFit.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		BindingContext = viewModel;
	}
}
