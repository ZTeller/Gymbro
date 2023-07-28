using GymBro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Commands
{
    class WPFinishWorkoutCommand : CommandBase
    {
        public GymBroWPViewModel _gymBroWPViewModel { get; set; }
        public WPFinishWorkoutCommand(GymBroWPViewModel gymBroWPViewModel)
        {
            _gymBroWPViewModel = gymBroWPViewModel;
        }

        public override void Execute(object parameter)
        {
            WorkoutModel Workouts = new WorkoutModel(new List<ExcerciseModel>(_gymBroWPViewModel.ExcerciseModelCollection));
            _gymBroWPViewModel.ExcerciseCollection.Clear();
            _gymBroWPViewModel.ExcerciseModelCollection.Clear();
            _gymBroWPViewModel.FinishedWorkouts.Add(Workouts);
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "wp.json");
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(_gymBroWPViewModel.FinishedWorkouts);
            File.WriteAllText(fullPath, jsonString);
            _gymBroWPViewModel.DateEnabled = true;
        }
    }
}
