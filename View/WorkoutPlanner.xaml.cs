namespace GymBro.View;

public partial class WorkoutPlanner : ContentPage
{
	public WorkoutPlanner(GymBroWPViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}