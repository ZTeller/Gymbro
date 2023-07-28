using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Model
{
    internal class BmiModel
    {
        public string Bmi { get; set; }

        public BmiModel(string bmi)
        {
            Bmi = bmi;
        }
    }
}
