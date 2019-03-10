using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {

        public string Name { get; }

        public string Type { get; }

        private Func<double, double> TheFunction;

        public event EventHandler<double> OnCalculate;



        public SingleMission(Func<double, double> func, string missionName)
        {
            this.Name = missionName;
            this.Type = "Single";
            this.TheFunction = func;
        }



        public double Calculate(double value)
        {
            double x = this.TheFunction(value);
            OnCalculate?.Invoke(this, x);
            return x;
        }
    }
}
