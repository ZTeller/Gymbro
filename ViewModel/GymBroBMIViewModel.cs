using GymBro.Commands;
using GymBro.Model;
using System.Windows.Input;

namespace GymBro.ViewModel
{
    public partial class GymBroBMIViewModel: BaseViewModel
    {
        public GymBroBMIViewModel()
        {
            Title = "Body Mass Index";
            getFromStorage();
            ButtonBMI = new GetBMICommand(this);
            ButtonText = "Get BMI";
            /*
            if (BMIstring == null)
            {
                ButtonText = "Get BMI";
            }
            else
            {
                ButtonText = BMIstring;
            }
            */

        }
        public ICommand ButtonBMI { get; }
        public void getFromStorage()
        {
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "bmi.json");
            try
            {
                string file = File.ReadAllText(fullPath);
                BmiModel jsonToText = Newtonsoft.Json.JsonConvert.DeserializeObject<BmiModel>(file);
                BMIstring = jsonToText.Bmi;
            }catch(Exception e)
            {
                return;
            }

        }
        public string BMIstring { get; set; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set
            { 
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
    }
}
