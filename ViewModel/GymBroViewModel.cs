using CommunityToolkit.Mvvm.Input;
using GymBro.Model;
using System.Collections.ObjectModel;

namespace GymBro.ViewModel
{
    public partial class GymBroViewModel : BaseViewModel
    {
        public GymBroViewModel()
        {
            getFromStorage();
            Task.Run(Refresher);
            Title = "Gym Bro";
        }

        public ObservableCollection<string> foodList { get; set; } = new();
        public List<CalorieModel> foodModelList = new List<CalorieModel>();
        public List<DateModel> DataLines { get; set; } = new List<DateModel>();
        public string EditedDate { get; set; }
        public string CalorieOutput { get; set; }

        async public Task Refresher()
        {
            while (true)
            {
                getFromStorage();
                Thread.Sleep(5000);
            }
        }

        public void getFromStorage()
        {
            Calories = "";
            var path = FileSystem.Current.AppDataDirectory;

            var fullPath = Path.Combine(path, "bmi.json");
            try
            {
                string file = File.ReadAllText(fullPath);
                BmiModel jsonToText = Newtonsoft.Json.JsonConvert.DeserializeObject<BmiModel>(file);
                Bmi = jsonToText.Bmi;
            }
            catch (Exception e)
            {
                return;
            }


            fullPath = Path.Combine(path, "ct.json");
            try
            {
                foodList.Clear();
                foodModelList.Clear();
                DataLines.Clear();
                EditedDate = "";
                CalorieOutput = "";
                string file = File.ReadAllText(fullPath);
                List<CalorieModel> jsonToText = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CalorieModel>>(file);
                foodModelList = jsonToText;
                foreach (CalorieModel item in foodModelList)
                {
                    if(item.Date == DateTime.Today.ToString("d"))
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
                foreach(string item in foodList)
                {
                    Calories += $"{item}\n";
                }
            }
            catch (Exception e)
            {
                return;
            }



            
            fullPath = Path.Combine(path, "wp.json");
            try
            {
                Workouts = "";
                string file = File.ReadAllText(fullPath);
                List<WorkoutModel> FinishedWorkouts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WorkoutModel>>(file);
                try
                {
                    string type = "";
                    foreach (var workout in FinishedWorkouts)
                    {
                        if (workout.ExcerciseModels[0].Date >= DateTime.Today)
                        {
                            for (int i = 0; i < workout.ExcerciseModels.Count; i++)
                            {
                                if (!type.Contains(workout.ExcerciseModels[i].Date.ToString("dd.MM.yyyy")))
                                {
                                    type += $"{workout.ExcerciseModels[i].Date.ToString("dd.MM.yyyy")}\n";
                                }
                                type += $"{workout.ExcerciseModels[i].ToString()}\n";
                            }
                        }
                    }
                    Workouts = type;
                }
                catch (Exception ex)
                {
                    // An unexpected error occured. No browser may be installed on the device.
                }
            }
            catch (Exception e)
            {
                return;
            }
            
        }

        private string _bmi;
        public string Bmi
        {
            get { return _bmi; }
            set
            {
                _bmi = value;
                OnPropertyChanged(nameof(Bmi));
            }
        }

        private string _calories;
        public string Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }

        private string _workouts;
        public string Workouts
        {
            get { return _workouts; }
            set
            {
                _workouts = value;
                OnPropertyChanged(nameof(Workouts));
            }
        }
    }
}
