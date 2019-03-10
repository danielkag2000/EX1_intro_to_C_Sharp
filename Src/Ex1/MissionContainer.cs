using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        private Dictionary<string, Func<double, double>> funcMap;

        public FunctionsContainer()
        {
            this.funcMap = new Dictionary<string, Func<double, double>>();
        }

        public Func<double, double> this[string funcName]
        {
            get
            {
                // if this function exists
                if (!funcMap.ContainsKey(funcName))
                    funcMap[funcName] = val => val; // defualt

                return funcMap[funcName];
            }

            set
            {
                funcMap[funcName] = value;
            }
        }


        public List<string> getAllMissions()
        {
            return funcMap.Keys.ToList();
        }

    }
}
