
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.AutomationPractice.Menu
{
    public class MenuPage
    {
        IWebDriver webDriver;

        public MenuPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void ClickContactUs()
        {
            IWebElement contactUsButton = webDriver.FindElement(By.Id("contact-link"));
            contactUsButton.Click();
        }
    }
}
