using GymBro.Commands;
using GymBro.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GymBro.ViewModel
{
    public partial class GymBroCTViewModel : BaseViewModel
    {
        public GymBroCTViewModel()
        {
            Title = "Calorie Tracker";
            getFromStorage();
            Calculate = new CalorieCommand(this);
        }
        public ICommand Calculate { get; }

        public ObservableCollection<string> foodList { get; set; } = new();
        public List<CalorieModel> foodModelList = new List<CalorieModel>();
        public List<DateModel> DataLines { get; set; } = new List<DateModel>();
        public string EditedDate { get; set; }

        public void getFromStorage()
        {
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "ct.json");
            try
            {
                string file = File.ReadAllText(fullPath);
                List<CalorieModel> jsonToText = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CalorieModel>>(file);
                foodModelList = jsonToText;
                foreach(CalorieModel item in foodModelList)
                {
                    IEnumerable<string> query = foodList.Where(s => s.Contains(item.Date));
                    if (!query.Any())
                    {
                        DateModel data_val = new DateModel(item.Date, 0);
                        foodList.Add(data_val.ToString());
                        DataLines.Add(data_val);
                    }
                    query = foodList.Where(s => s.Contains(item.Date));
                    IEnumerable<DateModel> query2 = DataLines.Where(s => s.Date == item.Date);
                    foreach (DateModel i in query2)
                    {
                        DataLines[DataLines.IndexOf(i)].Kcal += item.Kcal;
                        EditedDate = DataLines[DataLines.IndexOf(i)].ToString();
                    }
                    foreach (string i in query.ToList())
                    {
                        foodList.Insert(foodList.IndexOf(i) + 1, item.ToString());
                        foodList[foodList.IndexOf(i)] = EditedDate;
                    }
                }
            }
            catch (Exception e)
            {
                return;
            }

        }

        private string _food;
        public string Food
        {
            get { return _food; }
            set
            {
                _food = value;
                OnPropertyChanged(nameof(Food));
            }
        }

        private double _calories;
        public double Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }

        private double _quantity;
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }
}
