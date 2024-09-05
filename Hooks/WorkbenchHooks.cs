using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Workbench.Hooks
{
    [Binding]
    public sealed class WorkbenchHooks
    {
        private readonly IObjectContainer _container;
        public WorkbenchHooks(IObjectContainer container) 
        {
            _container = container;
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
           IWebDriver driver = new ChromeDriver();
           driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}