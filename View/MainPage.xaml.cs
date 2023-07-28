namespace GymBro.View;

public partial class MainPage : ContentPage
{
	public MainPage(GymBroViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
	}
}

