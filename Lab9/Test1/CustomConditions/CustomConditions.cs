using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.CustomConditions
{
    public class CustomConditions
    {
        public static Func<IWebDriver, bool> jQueryAJAXsCompleted()
        {
            return (driver) =>
            {
                return (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                        "return (window.jQuery != null) && (jQuery.active === 0);");
            };
        }
    }
}
