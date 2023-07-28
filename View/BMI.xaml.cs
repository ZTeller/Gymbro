namespace GymBro.View;

public partial class BMI : ContentPage
{
	public BMI(GymBroBMIViewModel bmi)
	{
		InitializeComponent();
		BindingContext = bmi;
	}
}