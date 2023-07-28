using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Model
{
    public class ExcerciseModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }


        public ExcerciseModel(DateTime date, string name, int sets, int reps, double weight)
        {
            Date = date;
            Name = name;
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Name} {Sets}x{Reps} with {Weight} Kg";
        }
    }
}
