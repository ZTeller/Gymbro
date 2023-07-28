using GymBro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Commands
{
    class WLFinishWorkoutCommand : CommandBase
    {
        public GymBroWLViewModel _gymBroWLViewModel { get; set; }
        public WLFinishWorkoutCommand(GymBroWLViewModel gymBroWLViewModel)
        {
            _gymBroWLViewModel = gymBroWLViewModel;
        }

        public override void Execute(object parameter)
        {
            WorkoutModel Workouts = new WorkoutModel(new List<ExcerciseModel>(_gymBroWLViewModel.ExcerciseModelCollection));
            _gymBroWLViewModel.ExcerciseCollection.Clear();
            _gymBroWLViewModel.ExcerciseModelCollection.Clear();
            _gymBroWLViewModel.FinishedWorkouts.Add(Workouts);
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "wl.json");
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(_gymBroWLViewModel.FinishedWorkouts);
            File.WriteAllText(fullPath, jsonString);
            _gymBroWLViewModel.DateEnabled = true;
        }
    }
}
