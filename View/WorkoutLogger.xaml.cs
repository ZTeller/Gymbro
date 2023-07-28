namespace GymBro.View;

public partial class WorkoutLogger : ContentPage
{
	public WorkoutLogger(GymBroWLViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}