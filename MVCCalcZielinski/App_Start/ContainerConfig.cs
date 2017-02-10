using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFCalcZielinski.Model;
using WPFCalcZielinski.Model.Operations;
using WPFCalcZielinski.Model.States;

namespace MVCCalcZielinski.App_Start
{
    public class ContainerConfig
    {
        public static void ConfigureContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IStateResolver, StateResolver>(Lifestyle.Singleton);
            container.Register<IStateFactory, StateFactory>(Lifestyle.Singleton);
            container.Register<IOperationsFactory, OperationsFactory>(Lifestyle.Singleton);
            container.Register<ICalculatorInstanceManager, CalculatorInstanceManager>(Lifestyle.Singleton);
            container.Register<ICalculator, Calculator>(Lifestyle.Transient);
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}