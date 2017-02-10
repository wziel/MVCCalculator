using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPFCalcZielinski.Model;

namespace MVCCalcZielinski.ViewModels.Home
{
    public class IndexVM
    {
        public string Text { get; set; }
        public bool DecimalPointEnabled { get; set; }
        public bool ButtonsEnabled { get; set; }

        public IndexVM()
        {
            //left empty
        }

        public IndexVM(ICalculator calculator)
        {
            Text = calculator.Text;
            DecimalPointEnabled = calculator.DecimalPointEnabled;
            ButtonsEnabled = !calculator.Error;
        }
    }
}