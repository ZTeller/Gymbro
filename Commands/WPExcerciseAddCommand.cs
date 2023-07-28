using GymBro.Model;
using GymBro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Commands
{
    class WPExcerciseAddCommand : CommandBase
    {
        private readonly GymBroWPViewModel _gymBroWPViewModel;

        public WPExcerciseAddCommand(GymBroWPViewModel gymBroWPViewModel)
        {
            _gymBroWPViewModel = gymBroWPViewModel;
        }
        public override void Execute(object parameter)
        {
            ExcerciseModel excercise = new ExcerciseModel(_gymBroWPViewModel.Date, _gymBroWPViewModel.Excercise, _gymBroWPViewModel.Sets, _gymBroWPViewModel.Reps, _gymBroWPViewModel.Weight);
            _gymBroWPViewModel.ExcerciseModelCollection.Add(excercise);
            _gymBroWPViewModel.ExcerciseCollection.Add(excercise.ToString());
            _gymBroWPViewModel.DateEnabled = false;
        }
    }
}
