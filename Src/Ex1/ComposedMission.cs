using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public string Name { get; }

        public string Type { get; }

        private Func<double, double> TheFunction;

        public event EventHandler<double> OnCalculate;

        private ComposedMission(Func<double, double> func, string missionName)
        {
            this.Name = missionName;
            this.Type = "Composed";
            this.TheFunction = func;
        }

        public ComposedMission(string missionName)
        {
            this.Name = missionName;
            this.Type = "Composed";
            this.TheFunction = val => val;
        }

        public ComposedMission Add(Func<double, double> func)
        {
            Func<double, double> tempFunc = new Func<double, double>(this.TheFunction);
            this.TheFunction = val => func(tempFunc(val));
            return this;
        }

        public double Calculate(double value)
        {
            double x = this.TheFunction(value);
            OnCalculate?.Invoke(this, x);
            return x;
        }
    }
}
