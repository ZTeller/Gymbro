using GymBro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Commands
{
    class WLExcerciseAddCommand : CommandBase
    {
        private readonly GymBroWLViewModel _gymBroWLViewModel;

        public WLExcerciseAddCommand(GymBroWLViewModel gymBroWLViewModel)
        {
            _gymBroWLViewModel = gymBroWLViewModel;
        }

        public override void Execute(object parameter)
        {
            ExcerciseModel excercise = new ExcerciseModel(_gymBroWLViewModel.Date,
                _gymBroWLViewModel.Excercise, _gymBroWLViewModel.Sets,
                _gymBroWLViewModel.Reps, _gymBroWLViewModel.Weight);
            _gymBroWLViewModel.ExcerciseModelCollection.Add(excercise);
            _gymBroWLViewModel.ExcerciseCollection.Add(excercise.ToString());
            _gymBroWLViewModel.DateEnabled = false;
        }
    }
}
