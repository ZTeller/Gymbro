namespace GymBro.View;

public partial class CalorieTracker : ContentPage
{
	public CalorieTracker(GymBroCTViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}