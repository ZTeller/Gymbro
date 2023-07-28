namespace GymBro.View;

public partial class MapScreen : ContentPage
{
	public MapScreen(GymBroMapViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}