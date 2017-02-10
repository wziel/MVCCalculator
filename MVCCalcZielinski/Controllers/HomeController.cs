using MVCCalcZielinski.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFCalcZielinski.Model;

namespace MVCCalcZielinski.Controllers
{
    public class HomeController : Controller
    {
        private ICalculatorInstanceManager calculatorInstanceManger;

        public HomeController(ICalculatorInstanceManager calculatorInstanceManger)
        {
            this.calculatorInstanceManger = calculatorInstanceManger;
        }

        public ActionResult Index()
        {
            var calculator = calculatorInstanceManger.Calculator;
            var vm = new IndexVM(calculator);
            return View(vm);
        }

        public ActionResult Command(string command)
        {
            var calculator = calculatorInstanceManger.Calculator;
            try
            {
                calculator.HandleCommand(command);
            }
            catch(CalculatorInvalidCommandException)
            {
                //do nothing
            }
            var vm = new IndexVM(calculator);
            return View("Index", vm);
        }
    }
}