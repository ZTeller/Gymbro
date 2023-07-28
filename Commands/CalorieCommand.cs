using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBro.Model;

namespace GymBro.Commands
{
    class CalorieCommand : CommandBase
    {
        private readonly GymBroCTViewModel _gymBroCTViewModel;
        public List<DateModel> DataLines { get; set; } = new List<DateModel>();
        public string EditedDate { get; set; }
        public CalorieCommand(GymBroCTViewModel gymBroCTViewModel)
        {
            _gymBroCTViewModel = gymBroCTViewModel;
        }

        public override void Execute(object parameter)
        {
            CalorieModel food = new CalorieModel(_gymBroCTViewModel.Food, _gymBroCTViewModel.Calories, _gymBroCTViewModel.Quantity);
            IEnumerable<string> query = _gymBroCTViewModel.foodList.Where(s => s.Contains(food.Date));
            if (!query.Any())
            {
                DateModel data_val= new DateModel(food.Date, 0);
                _gymBroCTViewModel.foodList.Add(data_val.ToString());
                DataLines.Add(data_val);
            }
            query = _gymBroCTViewModel.foodList.Where(s => s.Contains(food.Date));
            IEnumerable<DateModel> query2 = DataLines.Where(s => s.Date == food.Date);
            foreach (DateModel i in query2)
            {
                DataLines[DataLines.IndexOf(i)].Kcal += food.Kcal;
                EditedDate = DataLines[DataLines.IndexOf(i)].ToString();
            }
            foreach (string i in query.ToList())
            {
                _gymBroCTViewModel.foodList.Insert(_gymBroCTViewModel.foodList.IndexOf(i) + 1, food.ToString());
                _gymBroCTViewModel.foodList[_gymBroCTViewModel.foodList.IndexOf(i)] = EditedDate;
            }
            //_gymBroCTViewModel.foodList[_gymBroCTViewModel.foodList.IndexOf(food.Date)].Kcal += 2;
            _gymBroCTViewModel.foodModelList.Add(food);
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "ct.json");
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(_gymBroCTViewModel.foodModelList);
            File.WriteAllText(fullPath, jsonString);

        }
    }
}
