using GymBro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Commands
{
    class GetBMICommand : CommandBase
    {
        public double BMI { get; set; }
        private readonly GymBroBMIViewModel _gymBroBMIViewModel;
        public GetBMICommand(GymBroBMIViewModel gymBroBMIViewModel)
        {
            _gymBroBMIViewModel = gymBroBMIViewModel;
        }

        public override async void Execute(object parameter)
        {
            BMI = Math.Round(_gymBroBMIViewModel.Weight / Math.Pow(_gymBroBMIViewModel.Height / 100, 2), 2);
            _gymBroBMIViewModel.BMIstring = BMI.ToString();
            await Shell.Current.DisplayAlert("Your BMI:",
                $"{_gymBroBMIViewModel.BMIstring}", "OK");
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "bmi.json");
            BmiModel bmiModel = new BmiModel(BMI.ToString());
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(bmiModel);
            File.WriteAllText(fullPath, jsonString);
            /*
            string path = "data.json";
            if (!File.Exists(path))
            {
                dynamic jsonObj1 = Newtonsoft.Json.JsonConvert.DeserializeObject("{'BMI':0}");
                string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj1, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output1);
            }
            string json = File.ReadAllText(path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["BMI"] = BMI;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, output);
            */
        }
    }
}
