using OpenQA.Selenium;

namespace Workbench.Pages
{
    public class WorkbenchPageElements
    {

        private IWebDriver driver;

        public WorkbenchPageElements(IWebDriver driver) 
        {
            this.driver = driver; 
        }

        public string getTitle()
        {
            return driver.Title;
        }
    }
}