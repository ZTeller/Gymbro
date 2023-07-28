using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Model
{
    public class WorkoutModel
    {
        public List<ExcerciseModel> ExcerciseModels;
        public WorkoutModel(List<ExcerciseModel> excerciseModels)
        {
            ExcerciseModels = excerciseModels;
        }
    }
}
