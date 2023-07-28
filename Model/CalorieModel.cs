using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Model
{
    public class CalorieModel
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Quantity { get; set; }
        public double Kcal { get; set; }

        public CalorieModel(string name, double calories, double quantity)
        {
            Date = DateTime.Today.ToString("d");
            Name = name;
            Calories = calories;
            Quantity = quantity;
            Kcal = Calories * (Quantity / 100);

        }
        public override string ToString()
        {
            return $"{Name} - {Math.Round(Kcal,2)} kCal";
        }
    }
}
