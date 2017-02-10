using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCalcZielinski.App_Start
{
    public class LogConfig
    {
        public static void ConfigureLog()
        {
            log4net.Config.BasicConfigurator.Configure();
        }
    }
}