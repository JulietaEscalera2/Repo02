using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PageObjects.AutomationPractice.Buy
{
    public class SingInPage
    {
        IWebDriver webDriver;

        public SingInPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public enum Options
        {
            ByText,
            ByValue,
            ByIndex
        }

        public void SelectHeadingComboBox(Options option, string value)
        {
            IWebElement subjectHeading = webDriver.FindElement(By.ClassName("login"));
            SelectElement subjectHeadingComboBox = new SelectElement(subjectHeading);
            switch (option)
            {
                case Options.ByText:
                    subjectHeadingComboBox.SelectByText(value);
                    break;
                case Options.ByValue:
                    subjectHeadingComboBox.SelectByValue(value);
                    break;
                case Options.ByIndex:
                    subjectHeadingComboBox.SelectByIndex(int.Parse(value));
                    break;
            }
        }

        public void FillExistedCustomerForm(Options option, string email,string password)
        {
            SetEmailAddress(email);
            SetPassword(password);
            ClickSingIn();

        }

        private void ClickSingIn()
        {
            //submitSingInButton
            IWebElement singInButton = webDriver.FindElement(By.Id("SubmitLogin"));
            singInButton.Click();
        }

        private void SetPassword(string password)
        {
            //password
            IWebElement passwdInput = webDriver.FindElement(By.Id("passwd"));
            passwdInput.SendKeys(password);
        }

        private void SetEmailAddress(string email)
        {
            //set email address
            IWebElement emailAddress = webDriver.FindElement(By.Id("email"));
            emailAddress.SendKeys(email);
        }
    }
}
