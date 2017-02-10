using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPFCalcZielinski.Model;

namespace MVCCalcZielinski
{
    public class CalculatorInstanceManager : ICalculatorInstanceManager
    {
        private static readonly string sessionKey = "Calculator";
        private Container container;

        public CalculatorInstanceManager(Container container)
        {
            this.container = container;
        }

        public ICalculator Calculator
        {
            get
            {
                var calculator = (ICalculator) HttpContext.Current.Session[sessionKey];
                if(calculator == null)
                {
                    calculator = container.GetInstance<ICalculator>();
                    HttpContext.Current.Session[sessionKey] = calculator;
                }
                return calculator;
            }
        }
    }

    public interface ICalculatorInstanceManager
    {
        ICalculator Calculator { get; }
    }
}