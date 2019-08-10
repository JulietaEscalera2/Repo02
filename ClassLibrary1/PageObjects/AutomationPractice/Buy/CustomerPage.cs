using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Steps.AutomationPractice.Navegation;

namespace ClassLibrary1.PageObjects.AutomationPractice.Buy
{
    class CustomerPage
    {
        IWebDriver webDriver;

        public CustomerPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void fillCustomerData()
        {
            SingInPage logedPage = NavigationSteps.NavigateToSingIn();
            logedPage.FillExistedCustomerForm(SingInPage.Options.ByText, "julieta.escalera@gmail.com", "C0ntrol!");
        }


    }
}
