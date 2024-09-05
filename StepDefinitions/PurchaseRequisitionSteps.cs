using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Workbench.Pages;

namespace Workbench.StepDefinitions
{
    [Binding]
    public sealed class PurchaseRequisitionSteps
    {
        private IWebDriver driver;
        WorkbenchPageElements workbenchPage;

        public PurchaseRequisitionSteps(IWebDriver driver)
        { 
            this.driver = driver; 
        }

        [Given(@"I am at the Workbench login screen")]
        public void GivenIAmAtTheWorkbenchLoginScreen()
        {
            driver.Url = "https://web.workbench.co.nz/WorkbenchTestV4/Public.aspx/Login";
            Thread.Sleep(2000);
        }

        [Given(@"I log in as '([^']*)' user")]
        public void GivenILogInAsUser(String user)
        {
            if (user != "wbadmin")
            {
                Console.WriteLine("Unrecognized user. Please retry");
            } else
            {
                WhenIInputIntoTheTextBoxWithId(user, "userName");
                WhenIInputIntoTheTextBoxWithId("test", "userPassword");
                WhenIClickOnButtonById("loginButton");
                Thread.Sleep(3000);
            }
        }

        [When(@"I input '([^']*)' into the text box with id '([^']*)'")]
        public void WhenIInputIntoTheTextBoxWithId(string text, string id)
        {
            By textField = By.Id(id);
            driver.FindElement(textField).Clear();
            driver.FindElement(textField).SendKeys(text);
            Thread.Sleep(2000);
        }

        [When(@"I click on '([^']*)' item from UI autocomplete")]
        public void WhenICLickOnItemFromAutocomplete(String item)
        {
            Thread.Sleep(3000);
            var target = driver.FindElement(By.XPath("//span[text()='"+ item + "']"));
            Actions a = new Actions(driver);
            a.Click(target);
            a.Build().Perform();
        }

        [When(@"I click on button by title '([^']*)'")]
        public void WhenIClickOnButtonByTitle(String buttonTitle)
        {
            By button = By.XPath("//button[@title='"+buttonTitle+"']");
            driver.FindElement(button).Click();
            workbenchPage = new WorkbenchPageElements(driver);
            Thread.Sleep(2000);
        } 

        [When(@"I click on button by id '([^']*)'")]
        public void WhenIClickOnButtonById(String buttonId)
        {
            By button = By.Id(buttonId);
            driver.FindElement(button).Click();
            workbenchPage = new WorkbenchPageElements(driver);
            Thread.Sleep(2000);
        }

        [When(@"I click on button with text '([^']*)'")]
        public void WhenIClickOnButtonWithText(String buttonText)
        {
            By button = By.XPath(".//span[text()='"+ buttonText + "']");
            driver.FindElement(button).Click();
            workbenchPage = new WorkbenchPageElements(driver);
            Thread.Sleep(2000);
        } 

        [When(@"I navigate into the Purchase Requisitions screen")]
        public void WhenINavigateIntoThePurchaseRequisitionsScreen()
        {
            WhenIClickOnButtonById("sidebar-collapse");
            WhenIClickOnButtonById("Purchasing");
            WhenIClickOnButtonById("Purchase_Requisitions");
            WhenIClickOnButtonById("siteMapItem_Purchase_Requisitions_List");
        }

        [Then(@"The screen title is '([^']*)'")]
        public void ThenTheScreenTitleIs(string title)
        {
            Thread.Sleep(2500);
            Assert.AreEqual(title, workbenchPage.getTitle());
        }

        [Then(@"The purchase requisition success message is displayed")]
        public void ThenThePurchaseRequisitionSuccessMessageIsDisplayed()
        { 
           String success = driver.FindElement(By.XPath(".//*[@id='message']")).Text;
           Assert.AreEqual("Purchase Requisition successfully saved.", success);
           Thread.Sleep(2000);
        }

        [Then(@"The purchase requisition error message is displayed")]
        public void ThenThePurchaseRequisitionErrorMessageIsDisplayed()
        {
            String error = driver.FindElement(By.XPath(".//strong[text()='Your changes were not saved. Correct the following issues and try again:']")).Text;
            Assert.AreEqual("Your changes were not saved. Correct the following issues and try again:", error);
            Thread.Sleep(2000);
        }

        [Then(@"The '([^']*)' pop-up is displayed")]
        public void ThenTheConfirmSubmissionPopUpIsDisplayed(string input)
        {
            String actual = driver.FindElement(By.XPath(".//h4[text()='"+ input + "']")).Text;
            Assert.AreEqual(input, actual);
        }
    }
}
