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

        public ComposedMission(string missionName)
        {
            this.Name = missionName;
            this.Type = "Composed";
            this.TheFunction = val => val;
        }

        public ComposedMission Add(Func<double, double> func)
        {
            this.TheFunction += func;
            return this;
        }

        public double Calculate(double value)
        {
            foreach(Func<double, double> function in this.TheFunction.GetInvocationList())
            {
                value = function(value);
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }

        /*this is my first try, its work and its beautiful and elegant
        * but I didn't used this because I thought that it wasn't what the exercise
        * pointed to */
    
        /*public ComposedMission Add(Func<double, double> func)
        {
            Func<double, double> tempFunc = new Func<double, double>(this.TheFunction);
            this.TheFunction = val => func(tempFunc(val));
            return this;
        }

        public double Calculate(double value)
        {
            double x = this.TheFunction(x);
            OnCalculate?.Invoke(this, x);
            return x;
        }*/
    }
}
