using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Model
{
    public class DateModel
    {
        public string Date { get; set; }
        public double Kcal { get; set; }

        public DateModel(string date, double kcal)
        {
            Date = date;
            Kcal = kcal;
        }
        public override string ToString()
        {
            return $"{Date}: In total - {Kcal}";
        }
    }
}
