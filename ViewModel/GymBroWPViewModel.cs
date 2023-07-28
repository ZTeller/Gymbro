using GymBro.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GymBro.Model;
using CommunityToolkit.Mvvm.Input;

namespace GymBro.ViewModel
{
    public partial class GymBroWPViewModel:BaseViewModel
    {
        public GymBroWPViewModel()
        {
            Title = "Workout Planner";
            getFromStorage();
            AddToExcercise = new WPExcerciseAddCommand(this);
            Date = DateTime.Now;
            MinDate = DateTime.Now;
            DateEnabled = true;
            FinishExcercise = new WPFinishWorkoutCommand(this);
        }
        public ICommand AddToExcercise { get; }
        public ICommand FinishExcercise { get; }

        public void getFromStorage()
        {
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "wp.json");
            try
            {
                string file = File.ReadAllText(fullPath);
                List<WorkoutModel> jsonToText = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WorkoutModel>>(file);
                FinishedWorkouts = jsonToText;
            }
            catch (Exception e)
            {
                return;
            }

        }

        [RelayCommand]
        async Task OpenWorkoutsAsync()
        {
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
                await Shell.Current.DisplayAlert("Planned Workouts:",
                $"{type}", "OK");
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        public List<ExcerciseModel> Workouts;
        public List<WorkoutModel> FinishedWorkouts { get; set; } = new();
        public ObservableCollection<string> ExcerciseCollection { get; } = new();
        public ObservableCollection<ExcerciseModel> ExcerciseModelCollection { get; } = new();

        private bool _dateEnabled;
        public bool DateEnabled
        {
            get { return _dateEnabled; }
            set
            {
                _dateEnabled = value;
                OnPropertyChanged(nameof(DateEnabled));
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private DateTime _minDate;
        public DateTime MinDate
        {
            get { return _minDate; }
            set
            {
                _minDate = value;
                OnPropertyChanged(nameof(MinDate));
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

        private string _excercise;
        public string Excercise
        {
            get { return _excercise; }
            set
            {
                _excercise = value;
                OnPropertyChanged(nameof(Excercise));
            }
        }

        private int _reps;
        public int Reps
        {
            get { return _reps; }
            set
            {
                _reps = value;
                OnPropertyChanged(nameof(Reps));
            }
        }
        private int _sets;
        public int Sets
        {
            get { return _sets; }
            set
            {
                _sets = value;
                OnPropertyChanged(nameof(Sets));
            }
        }
    }
}
