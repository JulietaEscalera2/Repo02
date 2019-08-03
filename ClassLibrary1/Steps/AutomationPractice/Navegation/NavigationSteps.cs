using OpenQA.Selenium;
using PageObjectLibrary.AutomationPractice.ContactUs;
using PageObjectLibrary.AutomationPractice.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Steps.AutomationPractice.Navegation
{
    public class NavigationSteps
    {
        IWebDriver webDriver;

        public NavigationSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public ContactUsPage NavigateToContactUs()
        {
            MenuPage menuPage = new MenuPage(webDriver);
            ContactUsPage contactUsPage = menuPage.ClickContactUs();
            return contactUsPage;
        }
    }
}
